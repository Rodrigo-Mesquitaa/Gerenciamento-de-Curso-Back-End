import React from 'react';
import Alunos from './components/Alunos/Alunos';
import Turmas from './components/Turmas/Turmas';
import Matriculas from './components/Matriculas/Matriculas';
import './App.css';

const App = () => {
    return (
        <div className="App">
            <h1>Cursos de Idiomas</h1>
            <Alunos />
            <Turmas />
            <Matriculas />
        </div>
    );
};

export default App;