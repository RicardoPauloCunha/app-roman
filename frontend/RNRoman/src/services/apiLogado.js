import axios from "axios";

// url para chamada na api quando o usuário estiver logado, pois passa o Token
const apiLogado = axios.create({
    baseURL: "http://192.168.3.105:5000/api",
    headers: {
        "Content-Type": "application/json",
        "Authorization" : "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InJpY2FyZG8uc2FvQGhvdG1haWwuY29tIiwianRpIjoiMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFETUlOSVNUUkFET1IiLCJleHAiOjE1NTczMjU5MTQsImlzcyI6IlJvbWFuLk1hbmhhIiwiYXVkIjoiUm9tYW4uTWFuaGEifQ.7O8qZ4dIeolat7nY-SE-arTVoVgPIwdwjJ_lSE-L1k0"
    }
});

export default apiLogado;