const state = {
  caseManagementLabels:null,
  case:null,
  caseInformation: {
    id: "",
    caseId: "",
    description: "",
    messageFromClient: "",
    priority: null,
    createdOn: "",
    modifiedOn: ""
  },
  caseStatus: {
    status: null
  },
  references: [],
  notes: {
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
  caseManagementLabels:state => {
    return state.caseManagementLabels
  },
  case: state => {
    return state.case;
  },
  caseInformation: state => {
    return state.caseInformation;
  },
  clientDetails: state => {
    return state.clientDetails;
  },
  notes: state => {
    return state.notes;
  },
  caseStatus: state => {
    return state.caseStatus;
  },
  references: state => {
    return state.references;
  },
};

const mutations = {
  setCaseManagementLabels:(state,caseManagementLabels) => {
    state.caseManagementLabels = caseManagementLabels;
  },
  setCase: (state, someCase) => {
    state.case = someCase
  },
  setClientDetails: (state, clientData) => {
    state.clientDetails = clientData;
  },
  setCaseInformation: (state, caseInformation) => {
    state.caseInformation = caseInformation;
  },
  setCaseStatus: (state, caseStatus) => {
    state.caseStatus = caseStatus;
  },
  setNotes: (state, notes) => {
    state.notes = notes;
  },
  setReferences: (state, references) => {
    state.references = references;
  }
};

const actions = {
  setCaseManagementLabels:(context,caseManagementLabels) => {
    context.commit("setCaseManagementLabels",caseManagementLabels);
  },
  setCase: (context, someCase) => {
    context.commit("setClientDetails", someCase.client);
    context.commit("setCaseInformation", someCase.caseInformation);
    context.commit("setCaseStatus", someCase.caseStatus);
    context.commit("setNotes", someCase.notes);
    context.commit("setReferences", someCase.references);
    context.commit("setCase", someCase);
  },
  setClientDetails: (context, clientDetails) => {
    context.commit("setClientDetails", clientDetails);
  },
  setCaseInformation: (context, caseInformation) => {
    context.commit("setCaseInformation", caseInformation);
  },
  setCaseStatus: (context, caseStatus) => {
    context.commit("setCaseStatus", caseStatus);
  },
  setNotes: (context, notes) => {
    context.commit("setNotes", notes);
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
