<template>
  <div>
    <div class="sidebar" :class="{ active: toggleSideBar }">
      <div class="toggle-btn" v-on:click="changeSideBar">
        <span></span>
        <span></span>
        <span></span>
      </div>
      <ul class="sidebar-ul">
        <router-link to="#" active-class="active" tag="li"
          >Dashboard</router-link
        >
        <li>
          Case Management <span class="sub-arrow"></span>
          <ul>
            <router-link to="/case" active-class="active" tag="li"
              >Create new case</router-link
            >
          </ul>
        </li>
        <li>
          Declaration <span class="sub-arrow"></span>
          <ul>
            <router-link to="/declarationform" active-class="active" tag="li"
              >Create new declaration</router-link
            >
          </ul>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  data: () => {
    return {
      abcd: "hello",
      toggleSideBar: true
    };
  },
  methods: {
    changeSideBar() {
      this.toggleSideBar = !this.toggleSideBar;
    }
  }
};
</script>
<style>
@import url("./styles/sideBarStyle.css");
</style>
