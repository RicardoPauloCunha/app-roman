import React, { Component } from "react";

import { View, Text, FlatList, ScrollView, StyleSheet} from "react-native";

import apiLogado from "../services/apiLogado";

class Projetos extends Component {
    constructor(props) {
        super(props);

        this.state = {
            listaProjetos: []
        }
    }

    // carrrega a lista quando iniciar a pagina
    componentDidMount() {
        this.listarProjetos();
    }

    // função de listar os projetos
    listarProjetos = async () => {
        const respota = await apiLogado.get("/Projeto");
        const dadosLista = respota.data;
        this.setState({listaProjetos: dadosLista});
    };

    // layout
    render() {
        return (
            <ScrollView style={styles.projetosContainer}>
                <View style={styles.projetosHeader}>
                    <Text style={styles.projetosHeaderTitulo}>{"Projetos".toLocaleUpperCase()}</Text>
                </View>
                <View style={styles.projetosMain}>
                    {/* lista todos os Projetos */}
                    <FlatList
                        data={this.state.listaProjetos}
                        keyExtractor={item => item.projetoId}
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
                <Text style={styles.itemHeaderTitulo}>{item.titulo}</Text>
                <Text style={styles.itemHeaderTema}>{item.idTemaNavigation.tema}</Text>
            </View>
            <View style={styles.itemMain}>
                <Text style={styles.itemMainDescricao}>{item.descricao}</Text>
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
        width : "100%",
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

    // main (descrição)
    itemMainDescricao: {
        color: "#808080",
    }
})

export default Projetos;