import Vue from 'vue'
import {
  VParallax,
  VJumbotron,
  Vuetify,
  VApp,
  VNavigationDrawer,
  VTextField,
  VFooter,
  VList,
  VBtn,
  VIcon,
  VGrid,
  VCard,
  VDivider,
  VToolbar,
  VBreadcrumbs,
  transitions
} from 'vuetify'
import 'vuetify/src/stylus/app.styl'

Vue.use(Vuetify, {
  components: {
    VParallax,
    VJumbotron,
    VApp,
    VNavigationDrawer,
    VTextField,
    VFooter,
    VList,
    VBtn,
    VIcon,
    VGrid,
    VCard,
    VDivider,
    VToolbar,
    VBreadcrumbs,
    transitions
  },
  theme: {
    primary: '#000000',
    secondary: '#424242',
    accent: '#82B1FF',
    error: '#FF5252',
    info: '#2196F3',
    success: '#4CAF50',
    warning: '#FFC107'
  },
})
