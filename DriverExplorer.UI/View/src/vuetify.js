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
  VGrid,
  VLayout,
  VList,
  VListItem,
  VListItemTitle,
  VListItemAction,
  VListItemContent,
  VAppBar,
  VRow,
  VAppBarNavIcon,
  VBtn,
  VIcon,
  VImg,
  VToolbar,
  VTooltip,
  VDialog,
  VTextField,
  VToolbarTitle,
  VSelect,
  VCol,
  VSelectList,
  VSpacer
} from "vuetify/lib";

// vue-cli a-la-carte installation
Vue.use(Vuetify, {
  components: {
    VApp,
    VAlert,
    VCard,
    VGrid,
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
    VListItem,
    VRow,
    VCol,
    VTooltip,
    VListItemTitle,
    VListItemAction,
    VListItemContent,
    VAppBar,
    VAppBarNavIcon,
    VBtn,
    VIcon,
    VImg,
    VToolbar,
    VDialog,
    VTextField,
    VToolbarTitle,
    VSelect,
    VSelectList,
    VSpacer
  }
});

const opts = {
  theme: {
    themes: {
      dark: {
        primary: "#1976D2",
        secondary: "#424242",
        accent: "#82B1FF",
        error: "#FF5252",
        info: "#2196F3",
        success: "#4CAF50" 
      }
    }
  }
};

export default new Vuetify(opts);
