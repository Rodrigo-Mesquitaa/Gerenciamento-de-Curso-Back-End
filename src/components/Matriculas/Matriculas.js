import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './Matriculas.css';

const Matriculas = () => {
    const [matriculas, setMatriculas] = useState([]);

    useEffect(() => {
        const fetchMatriculas = async () => {
            try {
                const response = await axios.get('http://localhost:5000/api/matriculas');
                setMatriculas(response.data);
            } catch (error) {
                console.error("Erro ao buscar matrículas:", error);
            }
        };
        fetchMatriculas();
    }, []);

    return (
        <div className="matriculas">
            <h2>Matrículas</h2>
            <ul>
                {matriculas.map(matricula => (
                    <li key={matricula.id}>
                        Aluno ID: {matricula.alunoId}, Turma ID: {matricula.turmaId}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Matriculas;