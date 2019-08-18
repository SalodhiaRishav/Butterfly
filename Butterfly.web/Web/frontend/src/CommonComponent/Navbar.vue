<template>
  <div>
    <b-navbar class="mynavbar" type="dark">
      <b-navbar-nav>
        <router-link to="/home" active-class="active" tag="b-nav-item"
          >Home</router-link
        >
        <b-nav-item-dropdown text="Case management" right>
          <router-link to="/newcase" active-class="active" tag="b-dropdown-item"
            >Create new case</router-link
          >
        </b-nav-item-dropdown>
        <b-nav-item-dropdown text="Declarations" right>
          <router-link
            to="/declarationform"
            active-class="active"
            tag="b-dropdown-item"
            >Create new declaration</router-link
          >
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-navbar>
  </div>
</template>

<script>
export default {};
</script>

<style>
@import url(./styles/NavbarStyle.css);
</style>
