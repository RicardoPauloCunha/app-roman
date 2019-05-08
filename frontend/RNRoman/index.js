import {AppRegistry} from 'react-native';
import App from './App';
import {name as appName} from './app.json';
// import Login from "./src/pages/Login";
import Projetos from "./src/pages/Projetos";

AppRegistry.registerComponent(appName, () => Projetos);
