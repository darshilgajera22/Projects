// "StAuth10244: I Darshil Gajera, 000867069 certify that this material is my original work. No other person's work has been used without due acknowledgement. I have not made my work available to anyone else."


import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, TextInput, Button, FlatList, TouchableOpacity } from 'react-native';
import React, { useEffect, useState } from 'react';
import axios from 'axios';


/**
 * Login component 
 * @param {*} param0 
 * @returns 
 */
const LoginComponent = ({ onSignUp, setCurrentView }) => {
// usestate for username passord and error messge
  const [error, setErrormsg] = useState('');
  const [loginUsername, setLoginUsername] = useState('');
  const [loginPassword, setLoginPassword] = useState('');

  // seding request for log in 
  const loginUser = async () => {
    try {
      const response = await axios.post('http://localhost:3000/login', {
        username: loginUsername.trim(),
        password: loginPassword.trim(),
      });

      if (response.data.status === 'success') {
        // User successfully logged in, move to the GameComponent
        setCurrentView('game', loginUsername);
      } else {
        // error message
        setErrormsg('Username and/or password incorrect!!!');
      }
    } catch (error) {
      setErrormsg('Login failed!!!');
    }
  };

  return (
    <View style={styles.Logincontainer}>
      <Text style={styles.title2}>Login</Text>
      <TextInput
        style={styles.input}
        onChangeText={setLoginUsername}
        value={loginUsername}
        placeholder='Enter Username'
      />
      <TextInput
        style={styles.input}
        onChangeText={(text) => setLoginPassword(text)}
        value={loginPassword}
        placeholder='Enter Password'
        secureTextEntry
      />
      <View style={styles.LoginBtns}>
        <Button title='Login' onPress={loginUser} color={'#FFD28F'}></Button>
        <Button title='Sign Up' onPress={onSignUp} color={'#FFD28F'}></Button>
      </View>
      <Text style={styles.errorMessage}>{error}</Text>
    </View>
  )
}


/**
 * Sign up component
 * @param {*} param0 
 * @returns 
 */
const SignupComponent = ({ setCurrentView }) => {
  const [error, setErrormsg] = useState('');
  const [signupUsername, setSignupUsername] = useState('');
  const [signupPassword, setSignupPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');

  // sending sign up request
  const signupUser = async () => {
    try {
      // validating user data
      if (!signupUsername || !signupPassword) {
        setErrormsg('All fields must be completed');
        return;
      }

      // Check if signupPassword matches confirmPassword 
      if (signupPassword !== confirmPassword) {
        setErrormsg('Passwords do not match');
        return;
      }

      // Send signup request to the server
      const response = await axios.post('http://localhost:3000/signup', {
        username: signupUsername,
        password: signupPassword,
      });

      if (response.data.status === 'success') {
        // User successfully signed up, move to the GameComponent
        setCurrentView('game', signupUsername);
      } else {
        setErrormsg('Signup failed!!!');
      }
    } catch (error) {
      setErrormsg('Signup failed!!!');
    }
  };

  return (
    <View style={styles.Logincontainer}>
      <Text style={styles.title2}>Sign Up</Text>
      <TextInput
        style={styles.input}
        placeholder='Enter Username'
        onChangeText={(text) => setSignupUsername(text)}
        value={signupUsername}
      />
      <TextInput
        style={styles.input}
        placeholder='Enter Password'
        onChangeText={(text) => setSignupPassword(text)}
        value={signupPassword}
        secureTextEntry
      />
      <TextInput
        style={styles.input}
        placeholder='Confirm Password'
        onChangeText={(text) => setConfirmPassword(text)}
        value={confirmPassword}
        secureTextEntry
      />
      <Button title='Submit' onPress={signupUser} color={'#FFD28F'}></Button>
      <Text style={styles.errorMessage}>{error}</Text>
    </View>
  );
};

/**
 * Game component
 * @param {*} param0 
 * @returns 
 */
const GameComponent = ({ userName, setCurrentView }) => {
  // game state component
  const [number1, setNumber1] = useState(generateRandomNumber());
  const [number2, setNumber2] = useState(generateRandomNumber());
  const [userAnswer, setUserAnswer] = useState('');
  const [result, setResult] = useState(null);

  // cheking user answer
  const checkAnswer = async () => {
    const correctAnswer = number1 + number2;
    const userEnteredAnswer = parseInt(userAnswer, 10);

    // sending request to update result or add result in database
    if (userEnteredAnswer === correctAnswer) {
      setResult('Correct!'); // user answer is correct
      try {
        const response = await axios.post('http://localhost:3000/update', {
          username: userName,
          result: 'Correct',
        });
        console.log(response);
      }
      catch (error) {
        console.log("Error updating leaderboard:", error);
      }
    } else {
      // user answer is incorrect
      setResult('Incorrect!');
      // sending request to store data
      try {
        const response = await axios.post('http://localhost:3000/update', {
          username: userName,
          result: 'Incorrect',
        });
        console.log(response);
      }
      catch (error) {
        console.log("Error updating leaderboard:", error);
      }
    }
  };

  // redtarting the game
  const handleNextQuestion = () => {
    setNumber1(generateRandomNumber());// new random number
    setNumber2(generateRandomNumber()); // new random number
    setUserAnswer('');
    setResult(null);
  };

  return (
    <View style={styles.Logincontainer}>
      <Text style={styles.title}>Math Game</Text>
      <View>
        <Text>Number 1: {number1}</Text>
        <Text>Number 2: {number2}</Text>
        <TextInput
          style={styles.input}
          placeholder='Enter Your Answer'
          onChangeText={(text) => setUserAnswer(text)}
          value={userAnswer}
          keyboardType='numeric'
        />
        <Button title='Answer' onPress={checkAnswer} color={'#FFD28F'} />
        <Button title='Leaderboard' onPress={() => setCurrentView('leaderboard')} color={'#FFD28F'} />
      </View>
      {result !== null && (
        <View style={{ marginTop: 20 }}>
          <Text style={{ color: result === 'Correct!' ? 'green' : 'red' }}>
            {result}
          </Text>
          <Button title='Next Question' onPress={handleNextQuestion} color={'#FFD28F'} />
        </View>
      )}
      
    </View>
  );
};


/**
 * Leraderboard component to display learderboards
 * @returns 
 */
const LeaderboardComponent = () => {
  const [leaderboardData, setLeaderboardData] = useState([]);

  useEffect(() => {
    // Fetch leaderboard data from the server
    const fetchLeaderboardData = async () => {
      try {
        const response = await axios.post('http://localhost:3000/leaderboard');
        // setting data   of leaders in state
        setLeaderboardData(response.data.data);
      } catch (error) {
        console.error('Error fetching leaderboard data:', error);
      }
    };

    fetchLeaderboardData();
  }, []); // Empty dependency array, effect runs only once on mount

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Leaderboard</Text>
      <FlatList style = {styles.flatlistLeader}
        data={leaderboardData}
        keyExtractor={(item, index) => `${index}`}
        renderItem={({ item }) => (
          <View style={styles.leaderboardItem}>
            <Text style={styles.username}>{item.username}</Text>
          </View>
        )}
      />
    </View>
  );
};



/**
 * Main app component
 * @returns 
 */
export default function App() {
  const [currentView, setCurrentView] = useState('login'); // to change component
  const [loginUsername, setLoginUsername] = useState(null); // to set login user name

  // change current view and paasing user name
  const handleSetCurrentView = (view, username) => {
    setLoginUsername(username);
    setCurrentView(view);
  };

  /**
   * to render view as per user actions
   * @returns 
   */
  const renderCurrentView = () => {
    switch (currentView) {
      case 'login':
        return <LoginComponent onSignUp={() => handleSetCurrentView('signup')} setCurrentView={handleSetCurrentView} />;
      case 'signup':
        return <SignupComponent setCurrentView={handleSetCurrentView} userName={loginUsername} />;
      case 'game':
        return <GameComponent setCurrentView={handleSetCurrentView} userName={loginUsername} />;
      case 'leaderboard':
        return <LeaderboardComponent />;
      default:
        return null;
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Maths Number Game</Text>
      {renderCurrentView()} 
      <StatusBar style="auto" />
    </View>
  );
}


// style for UI components
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#99B080',
    alignItems: 'center',
    justifyContent: 'center',
  },
  Logincontainer: {
    backgroundColor: '#99B080',
    alignItems: 'center',
    justifyContent: 'center',
    borderWidth: 2,
    borderColor: '#F9B572',
    borderRadius: 10,
    padding: 30,
  },
  title: {
    fontSize: 30,
    fontWeight: 'bold',
    marginBottom: 20,
    color: '#F9B572',
    letterSpacing: 5,
  },
  flatlistLeader:{
    padding:20,
    textAlign: 'center',
    borderWidth: 2,
    borderColor: '#F9B572',
    borderRadius: 10,
    height:30,
    width:200,
  },
  username:{
    color: '#F9B572',
    fontSize: 40,
    fontWeight: 'bold',
    textAlign: 'center',
    textDecorationLine: 'underline',
  },
  title2: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 20,
    color: '#F9B572',
  },
  input: {
    height: 40,
    borderColor: '#ddd',
    borderWidth: 1,
    marginBottom: 20,
    padding: 10,
    width: '100%',
    borderRadius: 5,
    backgroundColor: '#fff',
  },
  errorMessage: {
    color: 'red',
    marginTop: 10,
    
  }

});


// Generate a random number between 1 and 100
const generateRandomNumber = () => Math.floor(Math.random() * 100) + 1;