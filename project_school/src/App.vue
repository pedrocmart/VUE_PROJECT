<template>
  <div id="app">
    <Nav></Nav>
    <div class="mainMargin">
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Alunos from "./components/Aluno/Alunos";
import Teachers from "./components/Teacher/Teachers";
import About from "./components/About/About";
import Nav from "./components/_nav/Nav";

export default {
  name: "App",
  components: {
    /* eslint-disable vue/no-unused-components */
    Alunos,
    Teachers,
    About,
    Nav,
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}
body,
html {
  margin: 0;
  height: 100%;
}

.mainMargin {
  width: 50%;
  margin: auto;
}

#app {
  width: 100%;
}

.btn {
  border: 1px solid black;
  padding: 10px 20px;
  color: white;
  font-size: 1.4em;
  border-radius: 5px;
}

.btnDanger {
  font-size: 0.8em;
  background-color: #fa4430;
}

.btn:hover {
  text-shadow: 1px 1px 1px black;
}

table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}
table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}
table thead th {
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}
.colPequeno {
  width: 5%;
  text-align: right;
  background-color: rgb(125, 217, 245);
  font-weight: bold;
}
</style>
