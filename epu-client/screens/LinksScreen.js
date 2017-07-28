import React from 'react';
import { AppRegistry, ScrollView, StyleSheet, Text, Image, Button } from 'react-native';

export default class LinksScreen extends React.Component {
    constructor(props) {
    super(props);

  }

  static navigationOptions = {
    title: 'Work Item',
    itemNumber: 0,
  };

  render() {
    const {state} = this.props.navigation;

    if (state.params === undefined)
      return(<Text>No item</Text>);
    else
      return (
      <ScrollView style={styles.container}>
        <Text>{state.params.data.displayQuestion}</Text>
        <Image 
            source={{uri: state.params.data.imageURI}} 
            style={{width: 400, height: 400}} 
        />
        <Button
            containerStyle={{padding:10, height:45, overflow:'hidden', borderRadius:4, backgroundColor: '#fff'}}
            style={{fontSize: 20, color: 'green'}}
            onPress={() => this.props.navigation.navigate('Home')}
              title="yes"
            width='50%' color='green'
 />
        <Button
            onPress={() => { alert('no')}}
            title="no"
         width='50%' color="red" />
      </ScrollView>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 15,
    backgroundColor: '#fff',
  }
});
