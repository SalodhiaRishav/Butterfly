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
@import url(./GlobalStyle.css);
</style>
