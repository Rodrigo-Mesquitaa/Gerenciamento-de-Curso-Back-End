import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './Turmas.css';

const Turmas = () => {
    const [turmas, setTurmas] = useState([]);

    useEffect(() => {
        const fetchTurmas = async () => {
            try {
                const response = await axios.get('http://localhost:5000/api/turmas');
                setTurmas(response.data);
            } catch (error) {
                console.error("Erro ao buscar turmas:", error);
            }
        };
        fetchTurmas();
    }, []);

    return (
        <div className="turmas">
            <h2>Turmas</h2>
            <ul>
                {turmas.map(turma => (
                    <li key={turma.id}>{turma.nome}</li>
                ))}
            </ul>
        </div>
    );
};

export default Turmas;