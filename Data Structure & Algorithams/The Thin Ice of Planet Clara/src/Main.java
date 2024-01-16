import java.io.File;
import java.io.IOException;
import java.util.Arrays;
import java.util.Scanner;

/**
 * Assignment #1 (The Thin Ice of Planet Clara)
 * COMP-10205 - Data Structures and algorithms
 * @author Darshil Gajera (000867069)
 */
public class Main {

    public static void main(String[] args) {

        int[][][] array = null; // 3d array to store txt file data

        File file = new File("src/ICESHEETS.TXT");
        try{
            // reading file data
            Scanner inputFile = new Scanner(file);
            int iceSheetCount = inputFile.nextInt();

            array = new int[iceSheetCount][][]; // initialize array with sheet number

            for (int k=0;k<iceSheetCount;k++){
                int fileRows = inputFile.nextInt();
                int fileCols = inputFile.nextInt();

                array[k] = new int[fileRows][fileCols]; // initialize array with rows and columns as per ice sheet number

                for (int i=0;i<fileRows;i++){
                    for (int j=0;j<fileCols;j++){
                        array[k][i][j] = inputFile.nextInt(); // storing data as per ice sheets number
                    }
                }
            }

            inputFile.close();

            // calling function to find fracture points and storing into an array
            FracturePoints[] fracturePointsLocations = fracturePoints(array);


            // calling function to find total cracks and passing fracture points && array of ice sheet
            System.out.println("\nTotal number of detected crack is " + crackPoints(fracturePointsLocations, array));

        }catch (IOException e){
            System.out.println("Error Reading File" + e.getMessage());
        }
    }


    /**
     * to calculates total cracks in ice sheets as per fracture points
     * @param fracturePoints 1d array that contains fracture points locations
     * @param array 3d array that contains ice sheets data
     * @return count - total number of cracks in all ice sheets
     */

    public static int crackPoints(FracturePoints[] fracturePoints, int[][][] array){
        int count = 0; // total cracks
        // fracture point location
        int iceSheetNo, fracturePointRow, fracturePointCol;

        // i == getting elements of fracture point array by index
        for (int i=0;i<fracturePoints.length;i++){

            iceSheetNo = fracturePoints[i].iceSheetNo;
            fracturePointRow = fracturePoints[i].fracturePointRow;
            fracturePointCol = fracturePoints[i].fracturePointCol;


            // to break the loop
            boolean flagFoundCrack = false;
            boolean flagArrayLengthis1 = false;

            // fracture row is 0 then no need to check -1 row
            if (fracturePointRow == 0){
                // j = row
                for (int j=fracturePointRow;j<=fracturePointRow+1;j++){

                    // if fracture col is 0 then no need to check -1 col
                    if (fracturePointCol==0){
                        //k= col
                        for (int k=fracturePointCol;k<=fracturePointCol+1;k++){

                            if (k == array[iceSheetNo][j].length){
                                flagArrayLengthis1 = true;
                                break;
                            }

                            // fracture point
                            if (k == fracturePoints[i].fracturePointCol){
                                continue;
                            }
                            if (array[iceSheetNo][j][k] % 10 == 0){
                                System.out.println("CRACK DETECTED @ [Ice Sheet "+ iceSheetNo + " - Location (" + j +", " + k + ")]");
                                count++;
                                flagFoundCrack = true;
                                break;
                            }
                        }
                        if (flagFoundCrack) {
                            break;
                        }
                    }
                    else {
                        for (int k=fracturePointCol-1;k<=fracturePointCol+1;k++){

                            // fracture point
                            if (k == fracturePoints[i].fracturePointCol){
                                continue;
                            }
                            if (array[iceSheetNo][j][k] % 10 == 0){
                                System.out.println("CRACK DETECTED @ [Ice Sheet "+ iceSheetNo + " - Location (" + j +", " + k + ")]");
                                count++;
                                flagFoundCrack = true;
                                break;
                            }
                        }
                        if (flagFoundCrack){
                            break;
                        }
                    }
                    if (flagArrayLengthis1){
                        break;
                    }

                }
            }
            else {
                for (int j=fracturePointRow-1;j<=fracturePointRow+1;j++){

                    if (j == array[iceSheetNo].length){
                        break;
                    }
                    else {
                        if (fracturePointCol == 0){
                            for (int k=fracturePointCol;k<=fracturePointCol+1;k++){

                                // fracture point
                                if (k == fracturePoints[i].fracturePointCol){
                                    continue;
                                }
                                // crack condition
                                if (array[iceSheetNo][j][k] % 10 == 0){
                                    System.out.println("CRACK DETECTED @ [Ice Sheet "+ iceSheetNo + " - Location (" + j +", " + k + ")]");
                                    count++;
                                    flagFoundCrack = true;
                                    break;
                                }
                            }
                            if (flagFoundCrack){
                                break;
                            }
                        }
                        else {
                            for (int k=fracturePointCol-1;k<=fracturePointCol+1;k++){

                                if (k == array[iceSheetNo][j].length){
                                    break;
                                }
                                // fracture point
                                if (k == fracturePoints[i].fracturePointCol && j == fracturePoints[i].fracturePointRow){
                                    continue;
                                }
                                // crack condition
                                if (array[iceSheetNo][j][k] % 10 == 0){
                                    System.out.println("CRACK DETECTED @ [Ice Sheet "+ iceSheetNo + " - Location (" + j +", " + k + ")]");
                                    count++;
                                    flagFoundCrack = true;
                                    break;
                                }
                            }
                            if (flagFoundCrack){
                                break;
                            }
                        }
                    }
                }
            }
        }

        double fraction = (double)count/fracturePoints.length;
        System.out.println(String.format("\nFraction of fracture point is %.3f",fraction));
        return count;
    }


    /**
     * to find the fracture points from the Ice Sheets and display the number of Ice Sheet that contains maximum fracture points
     * @param array 3d array that contains all Ice Sheets data
     * @return fracturePoints Total fracturePoints from all Ice SheetS
     */
    public static FracturePoints[] fracturePoints(int[][][] array){
        // array for storing fracture points and initialize with maximum storage capasity as per 3d array
        FracturePoints[] fracturePoints = new FracturePoints[array.length * array[0].length * array[0][0].length];

        int fpcount = 0; // to store fracture point on next index of array fracturePoints[]
        int maxSheetNumber = 0; // sheet number that contains maximum fracture points
        int maxSheetCount = 0; // per sheet maximum fracture points count
        int totalCount = 0; // total fracture point count from all sheet

        // k = ice sheet number
        for (int k=0; k<array.length; k++){

            int tempCount = 0; // to count fracture points on one ice sheet

            // i == row of ice sheet number
            for (int i=0;i< array[k].length;i++){

                // j == col of ice sheet number
                for (int j=0;j< array[k][i].length;j++){

                    // condition that calculate fracture points
                    if (array[k][i][j]<=200 && array[k][i][j] % 50 == 0){
                        tempCount++; // +1 tempCount
                        fracturePoints[fpcount++] = new FracturePoints(k,i,j); // adding fracture points in to array
                    }
                }
            }
            totalCount += tempCount; // adding count in total count

            // to find sheet number that contains max fracture points
            if (tempCount>maxSheetCount){
                maxSheetCount = tempCount;
                // storing sheet number that contains max fracture points
                maxSheetNumber = k; // maximum fracture point sheet number is 4 because my loop start at index 0 but in ICESHEET.txt it is 5th.
            }
        }

        // removing extra space from the array
        fracturePoints = Arrays.copyOf(fracturePoints, fpcount);

        // output
        System.out.println("\n\nICESHEET number " + maxSheetNumber + " has a maximum number of fracture points, that are " + maxSheetCount);
        System.out.println("Total fracture Points is " + totalCount + "\n\n");

        return fracturePoints; // returning fracture points
    }
}
