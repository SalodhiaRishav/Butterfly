const state = {
  caseInformation: {
    description: "",
    messageFromClient: "",
    priority: null
  },
  statusForm: {
    status: null
  },
  references: [],
  notesForm: {
    notesByCpa: ""
  },
  clientDetails: {
    clientIdentifier: "",
    identifierType: null,
    name: "",
    address: "",
    postalCode: "",
    city: "",
    country: null,
    email: ""
  }
};

const getters = {
  caseInformation: state => {
    return state.caseInformation;
  },
  clientDetails: state => {
    return state.clientDetails;
  },
  notesForm: state => {
    return state.notesForm;
  },
  statusForm: state => {
    return state.statusForm;
  },
  references: state => {
    return state.references;
  }
};

const mutations = {};

const actions = {};

export default {
  state,
  mutations,
  getters,
  actions
};
