const state = {
  caseToEdit: null,
  caseInformation: {
    id: "",
    caseId: "",
    description: "",
    messageFromClient: "",
    priority: null,
    createdOn: "",
    modifiedOn: ""
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
  },
  caseToEdit: state => {
    return state.caseToEdit;
  }
};

const mutations = {
  setCaseToEdit: (state, caseToEdit) => {
    state.caseToEdit = caseToEdit;
    state.caseInformation = caseToEdit.caseInformation;
    state.clientDetails = caseToEdit.client;
    state.statusForm = caseToEdit.caseStatus;
    state.references = caseToEdit.references;
    state.notesForm = caseToEdit.notes;
  },
  setClientDetails: (state, clientData) => {
    state.clientDetails = clientData;
  },
  setCaseInformation: (state, caseInformation) => {
    state.caseInformation = caseInformation;
  },
  setStatusForm: (state, statusForm) => {
    state.statusForm = statusForm;
  },
  setNotesForm: (state, notesForm) => {
    state.notesForm = notesForm;
  },
  setReferences: (state, references) => {
    state.references = references;
  }
};

const actions = {
  setCaseToEdit: (context, caseToEdit) => {
    context.commit("setCaseToEdit", caseToEdit);
  },
  setClientDetails: (context, clientDetails) => {
    context.commit("setClientDetails", clientDetails);
  },
  setCaseInformation: (context, caseInformation) => {
    context.commit("setCaseInformation", caseInformation);
  },
  setStatusForm: (context, statusForm) => {
    context.commit("setStatusForm", statusForm);
  },
  setNotesForm: (context, notesForm) => {
    context.commit("setNotesForm", notesForm);
  },
  setReferences: (context, references) => {
    context.commit("setReferences", references);
  }
};

export default {
  state,
  mutations,
  getters,
  actions
};
