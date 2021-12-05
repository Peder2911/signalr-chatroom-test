<template>
   <div id="root">
      <div class="header">
         <h1>Chatroom</h1>
         <h2>Hello {{ username }}</h2>
      </div>
      <div class="messages">
         <p> Say something! </p>
         <p v-for="message in messages" :key="message.id">
            <span>{{ message.username }}: {{ message.content }} </span>
         </p>
      </div>
      <div class="footer">
         <input v-model="current_message" type="text">
         <button v-on:click="post_message">Send</button>
      </div>
   </div>
</template>

<script>
import * as signalR from "@microsoft/signalr"

export default {
   name: "chatroom",
   data() {
   return {
      messages: [],
      id: 0,
      current_message: "Hello world",
      username: "peder",
      }
   },
   created(){
      this.connection = new signalR.HubConnectionBuilder()
         .withUrl("/chat")
         .build();
      this.connection.start()

      this.connection.on("MessageReceived", (username, message) => {
         this.messages.push({id: this.get_id(), username: username, content: message})
      })

   },

   methods: {
      get_id(){
         this.id++
         return this.id
      },

      post_message(){
         this.connection.send("NewMessage", "peder", this.current_message)
         console.log(`Sent message ${this.current_message}`)
      }
   },
}
</script>

<style scoped>
#root {
   display: grid;
   height: 100%;
   width: 100%;
   grid-template-rows: 200px 1fr 200px;
   grid-gap: 10px;
}

.messages {
   overflow-y: scroll;
   background: #faf;
   color: #246;
}
</style>
