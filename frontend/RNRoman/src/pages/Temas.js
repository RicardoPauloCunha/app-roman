import React, { Component } from "react";

import { View, Text, FlatList, ScrollView, StyleSheet, AsyncStorage } from "react-native";

import apiLogado from "../services/apiLogado";
// não esquecer de implentar as TAGs usada para desenvolver o html aki

class Temas extends Component {
    constructor(props) {
        super(props);

        this.state = {
            listaTemas: [],
        }
    }

    // carrrega a lista quando iniciar a pagina
    componentDidMount() {
        this.listarTemas();
    }

    // função de listar os projetos
    listarTemas = async () => {
        const token = await AsyncStorage.getItem("UsuarioToken");

        const respota = await apiLogado.get("/Tema", {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        const dadosLista = respota.data;
        this.setState({ listaTemas: dadosLista });

        console.warn(dadosLista)
    };

    // layout
    render() {
        return (
            <ScrollView style={styles.projetosContainer}>
                <View style={styles.projetosHeader}>
                    <Text style={styles.projetosHeaderTitulo}>{"Temas".toLocaleUpperCase()}</Text>
                </View>
                <View style={styles.projetosMain}>
                    {/* lista todos os Temas */}
                    <FlatList
                        data={this.state.listaTemas}
                        keyExtractor={item => item.temaid}
                        renderItem={this.renderizarItem}
                    />
                </View>
            </ScrollView>
        )
    }

    // função que carrega item por item aplicando o estilo abaixo
    renderizarItem = ({ item }) => (
        <View style={styles.itemContainer}>
            <View style={styles.itemHeader}>
                <Text style={styles.itemHeaderId}>{item.temaid}</Text>
                <Text style={styles.itemHeaderTema}>{item.tema}</Text>
            </View>
        </View>

    )
}

//estilos
const styles = StyleSheet.create({
    // container
    projetosContainer: {
        flex: 1,
        marginBottom: 30
    },

    // header
    projetosHeader: {
        width: "100%",
        height: 50,
        backgroundColor: "#0dadff",
        justifyContent: "center",
        alignItems: "center",
    },
    projetosHeaderTitulo: {
        color: "white",
        fontSize: 25
    },

    // main container
    projetosMain: {
        width: "100%",
        justifyContent: "center",
        alignItems: "center",
        marginTop: 20,
    },

    // item (projeto)
    // container
    itemContainer: {
        width: 250,
        margin: 10,
        borderColor: "#0dadff",
        borderRadius: 10,
        borderWidth: 0.9,
        padding: 15,
        paddingLeft: 10,
        paddingRight: 10
    },

    // header (titulo e tema)
    itemHeader: {
        justifyContent: "center",
        flexDirection: "row",
    },

    itemHeaderTema: {
        flex: 1,
        fontSize: 17,
        color: "#1C1C1C",
        textAlign: "left",
        marginLeft: 10
    },
    itemHeaderId: {
        fontSize: 15,
        color: "#4F4F4F",
        textAlign: "center"
    },
})

export default Temas;