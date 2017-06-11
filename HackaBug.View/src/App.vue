<template>
  <v-app id="app" class="white--text">
    <v-navigation-drawer class='grey darken-4' persistent light :mini-variant.sync="mini" v-model="drawer">
      <v-list class="pa-0">
        <v-list-item>
          <v-list-tile avatar tag="div"  class="white--text">
            <v-list-tile-avatar>
              <img src="./assets/logo-grande.png" />
            </v-list-tile-avatar>
            <v-list-tile-content >
              <v-list-tile-title>Bug App</v-list-tile-title>
            </v-list-tile-content>
            <v-list-tile-action >
              <v-btn icon @click.native.stop="mini = !mini">
                <v-icon class="white--text">chevron_left</v-icon>
              </v-btn>
            </v-list-tile-action>
          </v-list-tile>
        </v-list-item>
      </v-list>

        <menu-lista></menu-lista>

    </v-navigation-drawer>
    <v-toolbar fixed class="blue darken-3" light>
      <v-toolbar-side-icon light @click.native.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-toolbar-title>
        Bug App
      </v-toolbar-title>
    </v-toolbar>
    <main>
      <v-container fluid>
          <router-view></router-view>
      </v-container>
    </main>
  </v-app>
</template>

<script>
import MenuLista from '@/components/shared/menu/menu'
export default {
  name: 'app',
  components: { MenuLista },
  data () {
    return {
      drawer: true,
      mini: false,
      right: null
    }
  }
}
</script>

<style>

</style>
