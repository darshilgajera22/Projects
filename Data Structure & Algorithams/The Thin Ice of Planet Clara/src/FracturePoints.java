/**
 *
 * Assignment #1 (The Thin Ice of Planet Clara)
 * COMP-10205 - Data Structures and algorithms
 * @author Darshil Gajera (000867069)
 *
 * FracturePoints class that holds the locations of fracture points
 */
public class FracturePoints {

    int iceSheetNo; // ice sheet number
    int fracturePointRow; // fracture point row number
    int fracturePointCol; // fracture point column number

    /**
     * Constructor of FracturePoints class
     * @param iceSheetNo // ice sheet number
     * @param fracturePointRow // fracture points row number
     * @param fracturePointCol // fracture points column number
     */
    public FracturePoints(int iceSheetNo, int fracturePointRow, int fracturePointCol) {
        this.iceSheetNo = iceSheetNo;
        this.fracturePointRow = fracturePointRow;
        this.fracturePointCol = fracturePointCol;
    }


    /**
     * to print the fracture points
     * @return String
     */
    @Override
    public String toString() {
        return "FracturePoints{" +
                "iceSheetNo=" + iceSheetNo +
                ", fracturePointRow=" + fracturePointRow +
                ", fracturePointCol=" + fracturePointCol +
                '}';
    }


}
