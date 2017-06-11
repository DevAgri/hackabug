<template>

  <div id="Home">
    <v-card v-show="warningMessage" class="green--text">
      <v-card-title>{{ warningMessage }}</v-card-title>
    </v-card>
    <h3>{{ msg }}</h3>
    <v-container fluid> 
       <v-layout row>
        <v-flex xs4 v-for="estacao in estacoes" :key="estacao.id">
          <v-card>
            <v-card-row>
              <img src="../../assets/estacao.png">
                <v-card-text class="black--text">
                  {{ estacao.nome }}
                </v-card-text>
            </v-card-row>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
    
</template>
<script>
export default {
  name: 'Home',
  data () {
    return {
      msg: 'Estações',
      warningMessage: '',
      estacoes: []
    }
  },
  created () {
    this.$http.get('estacoes')
    .then(function (res) {
      this.estacoes = res.data
    }, function (err) {
      console.log(err)
      this.warningMessage = 'Não foi possível comunicar-se com o servidor'
    })
  }
}
</script>
<style>
</style>
