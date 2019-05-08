import React, { Component } from "react";

import { View, Text, FlatList, ScrollView, StyleSheet} from "react-native";

import api from "../services/api";

class Projetos extends Component {
    constructor(props) {
        super(props);

        this.state = {
            listaProjetos: []
        }
    }

    componentDidMount() {
        this.listarProjetos();
    }

    listarProjetos = async () => {
        const respota = await api.get("/Projeto");
        const dadosLista = respota.data;
        this.setState({listaProjetos: dadosLista});
    };

    render() {
        return (
            <ScrollView style={styles.projetosContainer}>
                <View style={styles.projetosHeader}>
                    <Text style={styles.projetosHeaderTitulo}>{"Projetos".toLocaleUpperCase()}</Text>
                </View>
                <View style={styles.projetosMain}>
                    <FlatList
                        data={this.state.listaProjetos}
                        keyExtractor={item => item.projetoId}
                        renderItem={this.renderizarItem}
                    />
                </View>
            </ScrollView>
        )
    }

    renderizarItem = ({ item }) => (
        <View style={styles.itemContainer}>
            <View style={styles.itemHeader}>
                <Text style={styles.itemHeaderTitulo}>{item.titulo}</Text>
                <Text style={styles.itemHeaderTema}>{item.idTemaNavigation.tema}</Text>
            </View>
            <View style={styles.itemMain}>
                <Text style={styles.itemMainDescricao}>{item.descricao}</Text>
            </View>
        </View>

    )
}

const styles = StyleSheet.create({
    projetosContainer: {
        flex: 1,
        marginBottom: 30
    },
    projetosHeader: {
        width: "100%",
        height: 50,
        backgroundColor: "#0dadff",
        // backgroundColor: "#0000cd",
        justifyContent: "center",
        alignItems: "center",
    },
    projetosHeaderTitulo: {
        color: "white",
        fontSize: 25
    },
    
    projetosMain: {
        width : "100%",
        justifyContent: "center",
        alignItems: "center",
        marginTop: 20,
    },

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
    itemHeader: {
        justifyContent: "center",
        marginBottom: 5,
    },
    itemHeaderTitulo: {
        fontSize: 17,
        color: "#1C1C1C",
        textAlign: "center",
        marginBottom: 7,
    },
    itemHeaderTema: {
        color: "#4F4F4F"
    },
    itemMainDescricao: {
        color: "#808080",
    }
})

export default Projetos;