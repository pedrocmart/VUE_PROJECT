import Vue from 'vue';
import Router from 'vue-router';
import Students from './components/Student/Students';
import Teachers from './components/Teacher/Teachers';
import About from './components/About/About';
import StudentDetail from './components/Student/StudentDetail'

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
                path: '/Student/:teacher_id',
                name: 'Students',
                component: Students
            },
            {
                path: '/studentsall',
                name: 'Students',
                component: Students
            },
            {
                path: '/studentDetail/:id',
                name: 'StudentDetail',
                component: StudentDetail
            },
            {
                path: '/About',
                name: 'About',
                component: About
            }
        ]
    }
)