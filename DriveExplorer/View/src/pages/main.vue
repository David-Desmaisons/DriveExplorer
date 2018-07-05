<template>
    <main>
      <v-content>
        <v-container fluid class="main-container">

        <v-layout row wrap>

          <v-flex xs6>
              <v-select
                :label="$t('Resource.SelectDrive')"
                :items="viewModel.Drives"
                item-text="DisplayName"
                v-model="viewModel.Drive"
                dark
              ></v-select>
          </v-flex>

          <v-flex xs6> 
            <text-button :text="$t('Resource.Process')" color="green darken-1" :command="viewModel.FileAnalyser.Run" :loading="viewModel.FileAnalyser.Computing"></text-button>
          </v-flex>

          <v-flex xs6> 
            <text-button :text="$t('Resource.Process')" color="green darken-1" :command="viewModel.FileAnalyser.Run" :loading="viewModel.FileAnalyser.Computing"></text-button>
          </v-flex>
          
        </v-layout>

        </v-container>
      </v-content>
    </main>
</template>

<script>
import textButton from '../components/textButton'
import iconButton from '../components/IconButton'

const props={
  viewModel: Object,
}

export default {
  components:{
    textButton,
    iconButton
  },
  methods:{
    enter(){
      const command = this.viewModel.AddItem;
      if (command)
        command.Execute()
    }
  },
  props
}
</script>

<style>
main {
  height: 100%;
}

.main-container {
  height: calc(100% - 50px);
  overflow-y: auto;
}
</style>




