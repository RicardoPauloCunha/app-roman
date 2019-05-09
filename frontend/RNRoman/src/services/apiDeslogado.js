import axios from "axios";

// url para chamada na api quando o usuário estiver deslogado, usanda no login
const apiDeslogado = axios.create({
    baseURL: "http://192.168.3.105:5000/api"
});

export default apiDeslogado;