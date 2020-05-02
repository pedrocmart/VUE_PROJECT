import Vue from 'vue';
import Router from 'vue-router';
import Alunos from './components/Aluno/Alunos';
import Teachers from './components/Teacher/Teachers';
import About from './components/About/About';
import AlunoDetalhe from './components/Aluno/AlunoDetalhe'

Vue.use(Router);

export default new Router(
    {
        routes: [
            {
                path: '/Teacher',
                name: 'Teachers',
                component: Teachers
            },
            {
                path: '/Aluno/:teacher_id',
                name: 'Alunos',
                component: Alunos
            },
            {
                path: '/alunosall',
                name: 'Alunos',
                component: Alunos
            },
            {
                path: '/alunoDetalhe/:id',
                name: 'AlunoDetalhe',
                component: AlunoDetalhe
            },
            {
                path: '/About',
                name: 'About',
                component: About
            }
        ]
    }
)