// "StAuth10244: I Darshil Gajera, 000867069 certify that this material is my original work. No other person's work has been used without due acknowledgement. I have not made my work available to anyone else."

// importing libraries
import { StatusBar } from 'expo-status-bar';
import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View, Button, FlatList, TextInput, Image } from 'react-native';


export default function App() {
  const [dish, setDish] = useState([]); // dish data response
  const [ingredients, setIngredients] = useState([]); // dish ingredients
  const [dishName, setDishName] = useState(''); // user input
  const [instructions, setInstructions] = useState([]); // instructions to make dish
  const [currentView, setCurrentView] = useState(null); // to change view of ingredients and instructions
  const [errorMsg, setErrorMessage] = useState(''); // to display error message if dish not find

  /**
   * to list all ingredients
   */
  async function listIngredients() {

    if (dishName != '') {
      setDish([]); // empty prev dish data
      setErrorMessage('');
      try {
        // fetch request to get json data
        const response = await fetch('https://www.themealdb.com/api/json/v1/1/search.php?s=' + dishName);
        const json = await response.json();

        // got response data
        if (json.meals && json.meals.length > 0) {
          const meal = json.meals[0]; // accesing the data
          const ingredientsList = []; 
          setDish(meal); // setting dish data
          for (let i = 1; i <= 20; i++) {
            const ingredient = meal['strIngredient' + i]; // extracting all ingrediwnts
            if (ingredient) {
              ingredientsList.push(ingredient); // pushing in an array
            }
          }
          
          setIngredients(ingredientsList); // setting ingredient using useState
          setCurrentView('ingredients'); // setting current view to ingredients
        }
        else {
          setIngredients([]); // set ingredients data to null
          setErrorMessage("Dish not found. Please enter a valid dish name."); // setting error message
          setCurrentView(null); // setting current view to null
        }

      } catch (Error) {
        console.log('Error: ', Error); // catching error 
      }
    } else {
      alert("Please enter Dish ex. Pizza"); // if user does not provide input
    }

  }

  /**
   * to get dish instructions to make dish
   */
  async function listInstruction() {

    if (dishName != '') {
      setDish([]); // empyt prev dish data
      setErrorMessage('');
      try {
         // fetch request to get json data
        const response = await fetch('https://www.themealdb.com/api/json/v1/1/search.php?s=' + dishName);
        const json = await response.json();

        // got response data
        if (json.meals && json.meals.length > 0) {
          const meal = json.meals[0]; // accesing the data
          setDish(meal);// setting dish data
          
          setInstructions(meal.strInstructions); // setting instructions using useState
          setCurrentView('instructions'); // setting current view to null
        }
        else {
          setInstructions(''); // set instruction data to null
          setErrorMessage("Dish not found. Please enter a valid dish name.");  // setting error message
          setCurrentView(null); // setting current view to null
        }
      } catch (Error) {
        console.log('Error: ', Error); // catching error
      }
    } else {
      alert("Please enter Dish ex. Pizza"); // if user does not provide input

    }

  }


/**
 * to display ingredients
 * @param {*} param0 
 * @returns 
 */
  const IngredientsSection = ({ ingredients }) => (
    <View>
      <View style={styles.imageText}>
        {/* Dish image */}
        <Image source={dish.strMealThumb} style={styles.dishImg} />
        {/* Dish name */}
        <Text style={styles.mealName}>{dish.strMeal}</Text>
      </View>
      {ingredients.length !== 0 && (
        <>
        {/* Ingredients list */}
          <Text style={styles.mealName}>Ingredients</Text>
          <FlatList style={styles.flatIngredients}
            data={ingredients}
            renderItem={({ item }) => <Text style={styles.ingredientText}>&bull;{item}</Text>}
            keyExtractor={(item, index) => index.toString()}
          />
        </>
      )}
    </View>
  );

  /**
   * to display instructions
   * @param {*} param0 
   * @returns 
   */
  const InstructionsSection = ({ instructions }) => (
    <View>
      <View style={styles.imageText}>
        {/* Dish image */}
        <Image source={dish.strMealThumb} style={styles.dishImg} />
        {/* Dish name */}
        <Text style={styles.mealName}>{dish.strMeal}</Text>
      </View>
      {instructions.length !== 0 && (
        <>
        {/* Dish instructions */}
          <Text style={styles.mealName}>Step by step Instructions</Text>
          <Text style={styles.instructionsText}>{instructions}</Text>
        </>
      )}
    </View>
  );



  return (
    <View style={styles.container}>
      {/* App Heading */}
      <Text style={styles.textTitle}>Royal Meal Recepies</Text>

      {/* User input */}
      <TextInput style={styles.userTextinput}
        placeholder='Enter Dish Name ex.Arrabiata'
        autoFocus
        onChangeText={(text) => setDishName(text)}
      />

      {/* Buttons to get ingredients and instructions */}
      <View style={styles.buttonView}>
        <View style={styles.buttonView2}>
          <Button onPress={listIngredients} title='List Ingredients' color={'#8B4513'} />
        </View>
        <View style={styles.buttonView2}>
          <Button onPress={listInstruction} title='List Instructions' color={'#8B4513'} />
        </View>
      </View>


      {/* if current view is set to ingredients */}
      {currentView === 'ingredients' && (
        <IngredientsSection ingredients={ingredients} />
      )}

      {/* if current view is set to instructions */}
      {currentView === 'instructions' && (
        <InstructionsSection instructions={instructions} />
      )}

        {/* Error message if user does not provide input */}
      {errorMsg && (
        <Text style={styles.errorMsg}>{errorMsg}</Text>
      )}

      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  // style for main container
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    backgroundColor: '#D2B48C',
    padding:10  
  },
  // style for app heading
  textTitle: {
    fontSize: 50,
    fontWeight: 'bold',
    fontFamily: 'Georgia',
    color: '#8B4513',
    letterSpacing: 10
  },
  // style for dish name
  mealName: {
    fontSize: 25,
    fontWeight: 'bold',
    textAlign: 'center',
    color: '#8B4513',
  },
  // style for user input
  userTextinput: {
    width: 500,
    height: 50,
    margin: 20,
    padding: 20,
    borderWidth: 1,
    borderColor: '#8B4513',
    borderRadius: 10,

  },
  // style for dish name
  imageText: {
    textAlign: 'center',
    color:'#8B4513',
  },

  // style for dish image 
  dishImg: {
    margin: 10,
    width: 500,
    height: 300
  },
  // style for button view
  buttonView: {
    flexDirection: 'row',
  },

  // style for button view
  buttonView2: {
    margin: 20,
  },
  // style for view of flatlist
  flatlistView: {
    flex: 2,
    flexDirection: 'row',
    justifyContent: 'space-evenly',
    
  },
  // style for flatlist ingredients
  flatIngredients: {
    width: 500,
    height: 'auto',
    borderWidth: 1,
    borderColor: '#8B4513',
    borderRadius: 10,
    padding: 20,

  },
  // style for instructions
  instructionsText: {
    width: 500,
    height: 'auto',
    borderWidth: 1,
    borderColor: '#000',
    borderRadius: 10,
    padding: 20,
    color:'#8B4513',
  },
  // style for ingredients 
  ingredientText: {
    fontStyle: 'italic',
    color:'#8B4513',
  },
  // style for error message
  errorMsg: {
    color: 'red',
    fontSize: 16,
    fontWeight: 'bold',
    marginVertical: 10,
  },
});
