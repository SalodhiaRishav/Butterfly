<template>
  <div id="app">  
    <main>
     
      <router-view></router-view>
      <!-- <declarationform></declarationform> -->
    </main>
  </div>
</template>

<script>
import declarationform from './Declaration/DeclarationForm'

export default {
  name: 'app',
  components : {
    declarationform
  },
  data () {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  overflow-x: hidden;
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
