import React, {Component} from "react";

import { View, Text, FlatList, ScrollView, StyleSheet, AsyncStorage} from "react-native";

import {} from "react-native";
import apiLogado from "../services/apiLogado";

class Professores extends Component {
    constructor(props) {
        super(props);

        this.state = {
            lsitaProfessores: ""
        }
    }

    componentDidMount() {
        this.listarProfessores();
    }

    listarProfessores = async () => {
        const token = await AsyncStorage.getItem("UsuarioToken");

        const resposta = await apiLogado.get("/Professor", {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        const dadosLista = resposta.data;
        this.setState({ lsitaProfessores: dadosLista});
    }

    render() {
        return(
            <ScrollView style={styles.professoresContainer}>
                <View style={styles.professoresHeader}>
                    <Text style={styles.professoresHeaderTitulo}>{"Professores".toLocaleUpperCase()}</Text>
                </View>
                <View style={styles.professoresMain}>
                    {/* lista todos os Professores */}
                    <FlatList
                        data={this.state.lsitaProfessores}
                        keyExtractor={item => item.professorId}
                        renderItem={this.renderizarItem}
                    />
                </View>
            </ScrollView>
        )
    }

    renderizarItem = ({item}) => (
        <View style={styles.itemContainer}>
            <View style={styles.itemHeader}>
                <Text style={styles.itemHeaderTitulo}>{item.idUsuarioNavigation.nome}</Text>
            </View>
            <View style={styles.itemMain}>
                <Text style={styles.itemMainDescricao}>Id: {item.professorId}</Text>
                <Text style={styles.itemMainDescricao}>Equipe: {item.idEquipeNavigation.nome}</Text>
            </View>
        </View>
    )
}

//estilos
const styles = StyleSheet.create({
    // container
    professoresContainer: {
        flex: 1,
        marginBottom: 30
    },

    // header
    professoresHeader: {
        width: "100%",
        height: 50,
        backgroundColor: "#0dadff",
        justifyContent: "center",
        alignItems: "center",
    },
    professoresHeaderTitulo: {
        color: "white",
        fontSize: 25
    },

    // main container
    professoresMain: {
        width: "100%",
        justifyContent: "center",
        alignItems: "center",
        marginTop: 20,
    },

    // item (professpres)
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

    // header (professor)
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

    // main (id equipe e id usuario)
    itemMain: {
        flexDirection: "row",
        justifyContent: "space-around",
    },
    itemMainDescricao: {
        color: "#808080",
    }
})

export default Professores;