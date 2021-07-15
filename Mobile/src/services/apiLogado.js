import axios from "axios";

const apiLogado = axios.create({
    baseURL: "http://192.168.3.105:5000/api"
});

export default apiLogado;