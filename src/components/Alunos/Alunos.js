import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './Alunos.css';

const Alunos = () => {
    const [alunos, setAlunos] = useState([]);

    useEffect(() => {
        const fetchAlunos = async () => {
            try {
                const response = await axios.get('http://localhost:5000/api/alunos');
                setAlunos(response.data);
            } catch (error) {
                console.error("Erro ao buscar alunos:", error);
            }
        };
        fetchAlunos();
    }, []);

    return (
        <div className="alunos">
            <h2>Alunos</h2>
            <ul>
                {alunos.map(aluno => (
                    <li key={aluno.id}>{aluno.nome}</li>
                ))}
            </ul>
        </div>
    );
};

export default Alunos;