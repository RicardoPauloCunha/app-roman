import axios from "axios";

import {AsyncStorage} from "react-native";

// url para chamada na api quando o usuário estiver logado, pois passa o Token
const apiLogado = axios.create({
    baseURL: "http://192.168.3.105:5000/api"
});

export default apiLogado;