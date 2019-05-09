import React, { Component } from "react";

import Login from "./pages/Login";
import ListaProjetos from "./pages/Projetos";
import CadastrarProjeto from "./pages/CadastrarProjeto";
import Temas from "./pages/Temas";

import { createAppContainer, createDrawerNavigator, createStackNavigator, createSwitchNavigator, createBottomTabNavigator } from "react-navigation";

const AuthStack = createStackNavigator({ Login });

const MenuNavigator = createAppContainer(
    createDrawerNavigator(
        {
            ListaProjetos,
            CadastrarProjeto,
            Temas
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
