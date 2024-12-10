import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5000/api/', // Altere conforme necessário
});

export const fetchAlunos = () => api.get('alunos');
export const fetchTurmas = () => api.get('turmas');
export const fetchMatriculas = () => api.get('matriculas');