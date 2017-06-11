<template>
  <div id="Praga" class="black--text">
    <v-card v-show="warningMessage" class="green--text">
      <v-card-title>{{ warningMessage }}</v-card-title>
    </v-card>
    <v-card>
      <v-card-title class="black--text">
        Pragas
        <v-spacer></v-spacer>
        <v-text-field
          append-icon="search"
          label="Buscar"
          single-line
          hide-details
          v-model="search"
        ></v-text-field>
      </v-card-title>
      <v-card-title class="black--text">
        <v-btn @click.native="muda()" v-show="!visible" floating small success>
          <v-icon light>add</v-icon>
        </v-btn>
          <div v-show="visible">
          Adicionar Praga
          <form v-on:submit.prevent="adiciona()">
            <v-text-field
            append-icon="add"
            label="Adicionar"
            single-line
            required
            v-model="nomePraga  "
          ></v-text-field>
          <v-btn success :disabled="isBusy" type="submit">Adicionar</v-btn>
          <v-btn errrr @click.native="muda()">Cancelar</v-btn>
          </form>
        </div>
        <div v-show="selected.length && !visible">
          <form v-on:submit.prevent="removeSelecionados()">
            <v-btn<v-btn error :disabled="isBusy" type="submit">Remover Selecionados</v-btn> 
          </form>
        </div>
      </v-card-title>
      <v-data-table
        v-bind:headers="headers"
        v-bind:items="items"
        v-bind:tr="search"
        v-model="selected"
        selected-key="id"
        select-all
        class="elevation-1"
      >
        <template slot="headers" scope="props">
          <span v-tooltip:bottom="{ 'html': props.item.text }">
            {{ props.item.text }}
          </span>
        </template>
        <template slot="items" scope="props">
          <td>
          <v-checkbox
            primary
            hide-details
            v-model="props.selected"
          ></v-checkbox>
        </td>
          <td class="text-xs-left">{{ props.item.nome }}</td>
          <td class="text-xs-left">{{ props.item.id }}</td>
        </template>
        <template slot="pageText" scope="{ pageStart, pageStop }">
          From {{ pageStart }} to {{ pageStop }}
        </template>
      </v-data-table>
  </v-card>
  </div>
</template>

<script>
import PragaService from '../../domain/praga/PragaService'
export default {
  name: 'Home',
  data () {
    return {
      isBusy: false,
      service: null,
      warningMessage: '',
      visible: false,
      nomePraga: '',
      msg: 'Pragas',
      search: '',
      selected: [],
      pagination: {},
      headers: [
        {
          text: 'Nome da Praga',
          value: 'nome',
          left: true
        },
        {
          text: 'Id',
          value: 'id',
          left: true
        }
      ],
      items: []
    }
  },
  created () {
    this.service = new PragaService(this.$http)
    this.service.load()
    .then(function (res) {
      console.log(res)
      this.items = res
    },
    function (err) {
      console.log(err)
      this.warningMessage = 'Houve um erro ao comunicar-se com o servidor'
    })
  },
  methods: {
    muda (e) {
      this.visible = !this.visible
    },
    adiciona () {
      this.isBusy = true
      this.service.add(this.nomePraga)
      .then(function (res) {
        this.warningMessage = 'Praga Adicionada com sucesso'
        this.nomePraga = ''
        this.service.load()
        .then(function (res) {
          this.items = res
          this.isBusy = false
        },
        function (err) {
          console.log(err)
          this.warningMessage = 'Houve um erro ao comunicar-se com o servidor'
          this.isBusy = false
        })
      },
      function (err) {
        console.log(err)
        this.warningMessage = 'Houve um erro ao comunicar-se com o servidor'
        this.isBusy = false
      })
    },
    removeSelecionados () {
      this.selected.forEach(function (element) {
        this.service.remove(element.id)
        .then(function (res) {
          let index = this.items.indexOf(element)
          console.log(index)
          this.items.splice(index, 1)
        }, function (err) {
          console.log(err)
          this.warningMessage = 'Houve um erro ao excluir a(s) praga(s)'
        })
      }, this)
    }
  }
}
</script>

<style>

</style>
