<template>
<chatroom></chatroom>
</template>

<script>
import Chatroom from "@/components/Chatroom"
import "@/style/app.css"

export default {
  name: 'App',
  components: {Chatroom}
}
</script>

<style>

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  height: 100vh;
  width: 100vw;
}
</style>
