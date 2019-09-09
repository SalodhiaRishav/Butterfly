<template>
<div>
    <b-row >
        <b-col>
            <appNavigationbar></appNavigationbar>
        </b-col>
    </b-row>    
        <appSideBar></appSideBar> 
        <div>
        
                 <button class="box">
                    <font-awesome-icon style="color:red; font-size:43px" icon="thumbtack"/> &nbsp; &nbsp; <span class="heading">Cases</span><br>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span class="count" >100</span>                   
                </button>
</div>
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
@import url("./styles/dashboard2.css");
@import url('https://fonts.googleapis.com/css?family=Roboto&display=swap');
</style>