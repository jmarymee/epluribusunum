import React from 'react';
import { AppRegistry, PropType, ListView, StyleSheet, Image, Text, Button, View, NavigatorIOS } from 'react-native';
import { WebBrowser } from 'expo';
import { Ionicons } from '@expo/vector-icons';
import Touchable from 'react-native-platform-touchable';

export default class ListOfWorkItemsView extends React.Component {
  static navigationOptions = {
    header: null,
  };

  constructor(props) {
    super(props);


    this.dataSource = new ListView.DataSource({
      rowHasChanged: (r1, r2) => r1 !== r2
    });

    if (this.props.items != null) {
      var dataObject = this.props.items;
      var rows = dataObject.map(item => {
        return { id: item.id, text: item.description };
      });

      this.state = {
        dataSource: this.dataSource
      };
    }

  }
    renderRow (item, sectionID, rowID) {
      //alert(item);
        return (
        <Touchable
          style={styles.option}
          background={Touchable.Ripple('#ccc', false)}
          onPress={() => this.props.navigation.navigate('Links', { data: item })}>
          <View style={{flexDirection: 'row'}}>
            <View style={styles.optionIconContainer}>
              <Ionicons name="ios-chatboxes" size={22} color="#ccc" />
            </View>
            <View style={styles.optionTextContainer}>
              <Text style={styles.optionText}>
                {item.displayQuestion}
              </Text>
            </View>
          </View>
        </Touchable>
        );
    }

    render() {
    return (
      <View>
        <Text style={styles.optionsTitleText}>
          Work Items
        </Text>

        <ListView dataSource={this.state.dataSource}
                    renderRow={(item, sid, rid) => this.renderRow(item, sid, rid)} />
      </View>
    );
  }

  _handleItemSelect = (itemSelected) => {
      

//    WebBrowser.openBrowserAsync('http://forums.expo.io');
  };

  componentDidMount() {
    return fetch('https://epuapi.azurewebsites.net/api/values')
      .then((response) => response.json())
      .then((responseJson) => {
        let ds = new ListView.DataSource({rowHasChanged: (r1, r2) => r1 !== r2});
        this.setState({
          isLoading: false,
          dataSource: ds.cloneWithRows(JSON.parse(responseJson.Data)),
        }, function() {
          // do something with new state
        });
      })
      .catch((error) => {
        console.error(error);
      });
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 15,
  },
  optionsTitleText: {
    fontSize: 16,
    marginLeft: 15,
    marginTop: 9,
    marginBottom: 12,
  },
  optionIconContainer: {
    marginRight: 9,
  },
  option: {
    backgroundColor: '#fdfdfd',
    paddingHorizontal: 15,
    paddingVertical: 15,
    borderBottomWidth: StyleSheet.hairlineWidth,
    borderBottomColor: '#EDEDED',
  },
  optionText: {
    fontSize: 15,
    marginTop: 1,
  },
});
