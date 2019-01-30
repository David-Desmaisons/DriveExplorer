import "material-design-icons/iconfont/material-icons.css";
import "@mdi/font/css/materialdesignicons.css";
import "font-awesome/css/font-awesome.css";

import Vue_Router from "vue-router";
import { router } from "./route";
import VueI18n from "vue-i18n";
import messages from "./message";
import Notifications from "vue-notification";
import textButton from "@/components/textButton";
import iconButton from "@/components/iconButton";

import Vuetify, {
  VApp,
  VAlert,
  VCard,
  VCardText,
  VCardMedia,
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
  VListTile,
  VListTileTitle,
  VListTileAction,
  VListTileContent,
  VBtn,
  VIcon,
  VImg,
  VToolbar,
  VDialog,
  VTextField,
  VToolbarSideIcon,
  VToolbarTitle,
  VSelect,
  VSpacer
} from "vuetify/lib";

function install(Vue) {
  Vue.use(Vuetify, {
    components: {
      VApp,
      VAlert,
      VCard,
      VCardText,
      VCardMedia,
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
      VListTile,
      VListTileTitle,
      VListTileAction,
      VListTileContent,
      VBtn,
      VIcon,
      VImg,
      VToolbar,
      VDialog,
      VTextField,
      VToolbarSideIcon,
      VToolbarTitle,
      VSelect,
      VSpacer
    }
  });

  Vue.use(Vue_Router);
  Vue.use(VueI18n);
  Vue.use(Notifications);
  Vue.component("text-button", textButton);
  Vue.component("icon-button", iconButton);
}

/*eslint no-unused-vars: ["error", { "args": "none" }]*/
function vueInstanceOption(vm) {
  const i18n = new VueI18n({
    locale: "en-US", // set locale
    messages // set locale messages
  });

  //Return vue global option here, such as vue-router, vue-i18n, mix-ins, ....
  return {
    router,
    i18n
  };
}

export { install, vueInstanceOption };
