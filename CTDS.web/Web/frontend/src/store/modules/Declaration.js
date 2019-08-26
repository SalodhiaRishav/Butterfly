const state = {
    declrationIdToEdit: "",
  };
  
  const getters = {
    declrationIdToEdit: state => {
      return state.declrationIdToEdit;
    },
  };
  
  const mutations = {
    setDeclrationIdToEdit: (state, declrationIdToEdit) => {
      state.declrationIdToEdit = declrationIdToEdit;
    },
  };
  
  const actions = {
    setDeclrationIdToEdit: (context, declrationIdToEdit) => {
      context.commit("setDeclrationIdToEdit", declrationIdToEdit);
    },
  };
  
  export default {
    state,
    mutations,
    getters,
    actions
  };
  