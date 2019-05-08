import React, { Component } from "react";

import { View, Text, FlatList, ScrollView, StyleSheet} from "react-native";

class Projetos extends Component {
    constructor(props) {
        super(props);

        this.state = {
            listaProjetos: [
                { id: "1", titulo: "Desennvo lvimento de Sistemas", descricao: "descricao do projeto 1", tema: "tema 1" },
                { id: "2", titulo: "Projeto 2", descricao: "descricao do projeto 2", tema: "tema 2" },
                { id: "3", titulo: "Projeto 3", descricao: "descricao do projeto 3", tema: "tema 3" },
                { id: "4", titulo: "Projeto 4", descricao: "descricao do projeto 4 aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", tema: "tema 4" },
                { id: "5", titulo: "Projeto 4", descricao: "descricao do projeto 4 aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", tema: "tema 4" },
                { id: "6", titulo: "Projeto 4", descricao: "descricao do projeto 4 aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", tema: "tema 4" }
            ]
        }
    }

    render() {
        return (
            <ScrollView style={styles.projetosContainer}>
                <View style={styles.projetosHeader}>
                    <Text style={styles.projetosHeaderTitulo}>{"Projetos".toLocaleUpperCase()}</Text>
                </View>
                <View style={styles.projetosMain}>
                    <FlatList
                        data={this.state.listaProjetos}
                        keyExtractor={item => item.id}
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
                <Text style={styles.itemHeaderTema}>{item.tema}</Text>
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