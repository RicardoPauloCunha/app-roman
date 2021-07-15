import React, { Component } from "react";
import { View, Text, FlatList, ScrollView, StyleSheet, AsyncStorage, TextInput, TouchableOpacity } from "react-native";

import apiLogado from "../services/apiLogado";

class Temas extends Component {
    constructor(props) {
        super(props);

        this.state = {
            listaTemas: [],
            tema: "",
            mensagem: ""
        }
    }

    componentDidMount() {
        this.listarTemas();
    }

    listarTemas = async () => {
        const token = await AsyncStorage.getItem("UsuarioToken");

        const resposta = await apiLogado.get("/Tema/TemasAtivos", {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });

        const dadosLista = resposta.data;
        this.setState({ listaTemas: dadosLista });
    };

    cadastrarTema = async () => {
        const token = await AsyncStorage.getItem("UsuarioToken");

        try {
            const resposta = await apiLogado.post("/Tema", {
                tema: this.state.tema,
                ativo: 1
            },
                {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });

            if (resposta.status === 200) {
                this.setState({ mensagem: "Tema cadastrado com sucesso!" });
                this.listarTemas();
            }
        }
        catch (erro) {
            this.setState({ mensagem: "Dados inválidos!" })
        }
    }

    render() {
        return (
            <ScrollView style={styles.projetosContainer}>
                <View style={styles.projetosHeader}>
                    <Text style={styles.projetosHeaderTitulo}>{"Temas".toLocaleUpperCase()}</Text>
                </View>

                <View style={styles.projetosMain}>
                    <FlatList
                        data={this.state.listaTemas}
                        keyExtractor={item => item.temaid}
                        renderItem={this.renderizarItem}
                    />

                    <View style={styles.mainCadastro}>
                        <Text style={styles.mainCadastroTitulo}>Cadastrar Temas</Text>
                        <View style={styles.mainCadastroLinha}></View>

                        <TextInput
                            style={styles.inputCadastro}
                            placeholder="Nome do Tema"
                            placeholderTextColor="#808080"
                            onChangeText={tema => this.setState({ tema })}
                        />

                        <TouchableOpacity
                            style={styles.buttonCadastro}
                            onPress={this.cadastrarTema}
                        >
                            <Text style={styles.buttonCadastroText}>Cadastrar</Text>
                        </TouchableOpacity>

                        <View style={styles.cadastroMensagem}>
                            <Text>{this.state.mensagem}</Text>
                        </View>
                    </View>
                </View>
            </ScrollView>
        )
    }

    renderizarItem = ({ item }) => (
        <View style={styles.itemContainer}>
            <View style={styles.itemHeader}>
                <Text style={styles.itemHeaderTema}>{item.tema}</Text>
            </View>

            <View>
                <Text style={styles.itemHeaderId}>Id: {item.temaid}</Text>
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
        justifyContent: "center",
        alignItems: "center",
    },
    projetosHeaderTitulo: {
        color: "white",
        fontSize: 25
    },
    projetosMain: {
        width: "100%",
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
    },
    itemHeaderTema: {
        flex: 1,
        fontSize: 17,
        color: "#1C1C1C",
        textAlign: "center"
    },
    itemHeaderId: {
        fontSize: 15,
        color: "#4F4F4F",
        textAlign: "left",
    },
    mainCadastro: {
        width: "100%",
        alignItems: "center",
        marginTop: 20
    },
    mainCadastroTitulo: {
        color: "#696969",
        fontSize: 25,
    },
    mainCadastroLinha: {
        width: "70%",
        height: 1,
        backgroundColor: "rgba(13, 173, 255, 0.5)",
        marginBottom: 25,
    },
    inputCadastro: {
        width: "80%",
        borderColor: "rgba(13, 173, 255, 0.3)",
        backgroundColor: "rgba(180, 206, 232, 0.1)",
        borderWidth: 0.9,
        borderRadius: 15,
        marginBottom: 15,
        color: "#808080",
        fontSize: 16,
        height: 50,
        paddingLeft: 10,
        paddingRight: 10,
    },
    buttonCadastro: {
        borderRadius: 20,
        backgroundColor: "#0dadff",
        marginTop: 15,
        padding: 7,
        paddingLeft: 17,
        paddingRight: 17
    },
    buttonCadastroText: {
        fontSize: 16,
        color: "white"
    },
    cadastroMensagem: {
        marginTop: 10
    }
})

export default Temas;