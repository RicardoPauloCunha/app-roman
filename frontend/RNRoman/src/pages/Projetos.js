import React, { Component } from "react";

import { View, Text, FlatList, ScrollView, StyleSheet} from "react-native";

class Projetos extends Component {
    constructor(props) {
        super(props);

        this.state = {
            listaProjetos: [
                { id: "1", titulo: "Projeto 1", descricao: "descricao do projeto 1", tema: "tema 1" },
                { id: "2", titulo: "Projeto 2", descricao: "descricao do projeto 2", tema: "tema 2" },
                { id: "3", titulo: "Projeto 3", descricao: "descricao do projeto 3", tema: "tema 3" },
                { id: "4", titulo: "Projeto 4", descricao: "descricao do projeto 4", tema: "tema 4" }
            ]
        }
    }

    render() {
        return (
            <View style={styles.projetosContainer}>
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
            </View>
        )
    }

    renderizarItem = ({ item }) => (
        <View>
            <View>
                <Text>{item.titulo}</Text>
                <Text>{item.tema}</Text>
            </View>
            <View>
                <Text>{item.descricao}</Text>
            </View>
        </View>

    )
}

const styles = StyleSheet.create({
    projetosContainer: {
        flex: 1
    },
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
    projetosMain: {
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
    }
})

export default Projetos;