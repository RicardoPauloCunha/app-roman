import React, { Component } from "react";

import { View, Text, FlatList, ScrollView, StyleSheet, AsyncStorage, TextInput, TouchableOpacity} from "react-native";

import apiLogado from "../services/apiLogado";
// não esquecer de implentar as TAGs usada para desenvolver o html aki

class Temas extends Component {
    constructor(props) {
        super(props);

        this.state = {
            listaTemas: [],
            tema: "",
            mensagem: ""
        }
    }

    // carrrega a lista quando iniciar a pagina
    componentDidMount() {
        this.listarTemas();
    }

    // função de listar os projetos
    listarTemas = async () => {
        const token = await AsyncStorage.getItem("UsuarioToken");

        const resposta = await apiLogado.get("/Tema", {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        const dadosLista = resposta.data;
        this.setState({ listaTemas: dadosLista });

        console.warn(dadosLista)
    };

    // cadastro de temas
    _cadastrarTema = async () => {
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

            // manipula a respota
            if(resposta.status === 200) {
                this.setState({mensagem: "Tema cadastrado com sucesso!"});
                this.listarTemas();
            }
        }
        catch(erro) {
            this.setState({mensagem: "Dados inválidos!"})
        }
    }

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

                    {/* cadastra um novo tema */}
                    <View style={styles.mainCadastro}>
                        <Text style={styles.mainCadastroTitulo}>Cadastrar Temas</Text>
                        <View style={styles.mainCadastroLinha}></View>
                        {/* Formulario de cadastro de Temas */}
                        <TextInput
                            style={styles.inputCadastro}
                            placeholder="Nome do Tema"
                            placeholderTextColor="#808080"
                            onChangeText={tema => this.setState({ tema })}
                        />
                        <TouchableOpacity
                            style={styles.buttonCadastro}
                            onPress={this._cadastrarTema}
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

    // item (tema)
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

    // item
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

    // form (formulario de cadastro)
    // form container
    mainCadastro: {
        width: "100%",
        alignItems: "center",
        marginTop: 20
    },

    // form header (titulo) 
    mainCadastroTitulo: {
        color: "#696969",
        fontSize: 25,
    },
    // linha
    mainCadastroLinha: {
        width: "70%",
        height: 1,
        backgroundColor: "rgba(13, 173, 255, 0.5)",
        marginBottom: 25,
    },

    // inputs e butões
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

    //Mensagem erro
    cadastroMensagem: {
        marginTop: 10
    }
})

export default Temas;