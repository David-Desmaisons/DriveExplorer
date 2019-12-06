<template>
  <v-container fluid>
    <v-layout row wrap>
      <v-container class="grey lighten-5">
        <v-row no-gutters>
          <v-col v-for="n in 3" :key="n" cols="12" sm="4">
            <v-card class="pa-2" outlined tile>
              One of three columns
            </v-card>
          </v-col>
        </v-row>
      </v-container>

      <v-card>
        <v-card-title>
          Test Cases
          <v-spacer></v-spacer>
          <v-text-field
            v-model="viewModel.SearchCase"
            append-icon="search"
            label="Search"
            :items-per-page="5"
            single-line
            hide-details
          ></v-text-field>
        </v-card-title>
        <v-data-table
          :headers="viewModel.Headers"
          :items="viewModel.FTCsCasesFiltered"
          :loading="viewModel.TableLoading"
          :search="viewModel.SearchCase"
        ></v-data-table>
      </v-card>
    </v-layout>
  </v-container>
</template>

<script>
const props = {
  viewModel: Object
};

export default {
  props,
  computed: {
    completeDescription() {
      return this.viewModel.Descriptions.join(".<br>") + ".";
    }
  }
};
</script>
