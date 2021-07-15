import CadastrarProjeto from "./pages/CadastrarProjeto";
import Login from "./pages/Login";
import Professores from "./pages/Professores";
import Projetos from "./pages/Projetos";
import Temas from "./pages/Temas";

import { createAppContainer, createDrawerNavigator, createStackNavigator, createSwitchNavigator, createBottomTabNavigator } from "react-navigation";

const AuthStack = createStackNavigator({ Login });

const MenuNavigator = createAppContainer(
    createDrawerNavigator(
        {
            Projetos,
            CadastrarProjeto,
            Temas,
            Professores,
            Login
        }
    )
);

export default createAppContainer(
    createSwitchNavigator(
        {
            AuthStack,
            MenuNavigator
        },
        {
            initialRouteName: "AuthStack"
        }
    )
)
