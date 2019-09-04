<template>
<div>
    <b-row >
        <b-col>
            <appNavigationbar></appNavigationbar>
        </b-col>
    </b-row>    
        <appSideBar></appSideBar> 
</div>

</template>
<script>
import SideBar from "./SideBar";
import Navigationbar from "./Navigationbar";
export default {
    components:{
        appSideBar:SideBar,
        appNavigationbar:Navigationbar
    }
}
</script>
<style scoped>

</style>