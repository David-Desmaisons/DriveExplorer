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
              :item-value="v => v"
              v-model="viewModel.Drive"
              dark
            ></v-select>
          </v-flex>

          <v-flex xs6>
            <text-button
              :text="$t('Resource.Process')"
              color="green darken-1"
              :command="viewModel.FileAnalyser.Run"
              :loading="viewModel.FileAnalyser.Computing"
            ></text-button>
          </v-flex>

          <v-flex xs6 v-if="viewModel.Progress">
            {{ viewModel.Progress }} {{ $t("Resource.FilesAnalyzed") }}
          </v-flex>

          <div class="sunburst">
            <sunburst v-if="viewModel.Root" :data="dataFiles">
              <!-- Add behaviors -->
              <template slot-scope="{ nodes, actions }">
                <highlightOnHover :nodes="nodes" :actions="actions" />
                <zoomOnClick :nodes="nodes" :actions="actions" />
              </template>

              <!-- Add information to be displayed on top the graph -->
              <nodeInfoDisplayer
                slot="top"
                slot-scope="{ nodes }"
                :current="nodes.mouseOver"
                :root="nodes.root"
                :showAllNumber="false"
                description=""
              />

              <!-- Add bottom legend -->
              <breadcrumbTrail
                slot="legend"
                slot-scope="{ nodes, colorGetter, width }"
                :current="nodes.mouseOver"
                :root="nodes.root"
                :colorGetter="colorGetter"
                :from="nodes.clicked"
                :width="width"
              />
            </sunburst>
          </div>
        </v-layout>
      </v-container>
    </v-content>
  </main>
</template>

<script>
import {
  breadcrumbTrail,
  highlightOnHover,
  nodeInfoDisplayer,
  sunburst,
  zoomOnClick
} from "vue-d3-sunburst";
import "vue-d3-sunburst/dist/vue-d3-sunburst.css";

function map(data) {
  if (data === null) {
    return null;
  }
  const rawSize = data.Size;
  const size = rawSize == null ? null : rawSize.Value;
  const name = data.Name;
  const rawChildren = data.Children;
  const children =
    rawChildren === null ? null : rawChildren.map(child => map(child));
  return { name, children, size };
}

const props = {
  viewModel: Object
};

export default {
  components: {
    breadcrumbTrail,
    highlightOnHover,
    nodeInfoDisplayer,
    sunburst,
    zoomOnClick
  },
  methods: {},
  computed: {
    dataFiles() {
      const root = this.viewModel.Root;
      return map(root);
    }
  },
  props
};
</script>
