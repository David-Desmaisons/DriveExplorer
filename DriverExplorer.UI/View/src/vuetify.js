import "@mdi/font/css/materialdesignicons.css";
import Vue from "vue";
import Vuetify, {
  VApp,
  VAlert,
  VCard,
  VCardText,
  VCardTitle,
  VCardActions,
  VContent,
  VContainer,
  VDivider,
  VNavigationDrawer,
  VFooter,
  VFlex,
  VLayout,
  VList,
  VBtn,
  VIcon,
  VImg,
  VToolbar,
  VDialog,
  VTextField,
  VToolbarTitle,
  VSelect,
  VSpacer
} from "vuetify/lib";

// vue-cli a-la-carte installation
Vue.use(Vuetify, {
  components: {
    VApp,
    VAlert,
    VCard,
    VCardText,
    VCardTitle,
    VCardActions,
    VContent,
    VContainer,
    VDivider,
    VNavigationDrawer,
    VFooter,
    VFlex,
    VLayout,
    VList,
    VBtn,
    VIcon,
    VImg,
    VToolbar,
    VDialog,
    VTextField,
    VToolbarTitle,
    VSelect,
    VSpacer
  }
});

const opts = {
  theme: {
    themes: {
      light: {
        primary: "#1976D2",
        secondary: "#424242",
        accent: "#82B1FF",
        error: "#FF5252",
        info: "#2196F3",
        success: "#4CAF50"
      }
      // dark: {
      // }
    }
  }
};

export default new Vuetify(opts);
