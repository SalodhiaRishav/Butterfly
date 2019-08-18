<template>
   <div>
        <h2>Login</h2>
        <form @submit.prevent="handleSubmit">
            <div class="form-group">
                <label for="email">Email</label>
                <input type="email" v-model="email" name="email" class="form-control" :class="{ 'is-invalid': submitted && !email }" />
                <div v-show="submitted && !email" class="invalid-feedback">email is required</div>
            </div>
            <div class="form-group">
                <label htmlFor="password">Password</label>
                <input type="password" v-model="password" name="password" class="form-control" :class="{ 'is-invalid': submitted && !password }" />
                <div v-show="submitted && !password" class="invalid-feedback">Password is required</div>
            </div>
            <div class="form-group">
                <button class="btn btn-primary">Login</button>
            </div>
            <!-- <div v-if="error" class="alert alert-danger">{{error}}</div> -->
        </form>
    </div>
</template>

<script>
import axios from 'axios';
export default {
     data () {
        return {
            email: '',
            password: '',
            submitted: false,
            returnUrl: '',
            error: ''
        }
    },
    methods:{
        handleSubmit(){
            const url="https://localhost:44313/checkuser"
            const loginData={
                email:this.email,
                password:this.password
            }
            axios.post(url,loginData)
            .then(response =>{
                if(response.data.success === true)
                {
                    this.$store.dispatch("setRefreshTokenSerial",response.data.data.refreshTokenSerial);
                    this.$store.dispatch("setAccessToken","bearer "+response.data.data.accessToken);
                    this.$router.push("/home")
                }
                else
                {
                    alert(response.data.message);
                }
            })
            .catch(error=>{
                    alert(error);
            })
        }
    }

}
</script>

<style>

</style>
