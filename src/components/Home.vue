<template>
	<v-container fluid>


		<!--
			http://blog.dmatter.co/wp-content/uploads/2016/02/1305675722-room-class-school-classroom-teacher-blackboard-college-wallpaper-wallpaper.jpg
			http://www.thetradingfraternity.com/wp-content/uploads/2014/05/graduatee.jpg
			http://www.etrainingpedia.com/wp-content/uploads/2014/06/DT_4_11_13_005_Google+_Titelfoto_01.jpg
			<div class="v-parallax__image-container">
				<img src="@/assets/education.jpg" class="v-parallax__image" style="display: block; opacity: 1; transform: scale(.7) translate(-1450px, 300px);">
			</div>
		-->
		
		<v-parallax id='fuckPadding' src="https://image.shutterstock.com/z/stock-photo-classmate-classroom-sharing-international-friend-concept-410522830.jpg">
			<v-jumbotron :gradient="gradient" dark height='500px'>
			<v-layout align-center justify-end column fill-height>
				<v-btn class='mb-5' color='orange' dark large >Start learning for free</v-btn>
				<h1 class='display-2 font-weight-black mb-4 white--text'>WELCOME TO TRAILHEAD</h1>
				<h4 class='mb-5 headline font-weight-medium white--text'>The true way to learn Salesforce</h4>
			</v-layout>
			</v-jumbotron>
		</v-parallax>
		<v-layout dark>
			
		</v-layout>
	</v-container>
</template>

<script>
export default {
	name: 'Home',
	props: {
		msg: String
	},
	data: () => ({
		gradient: 'to top, rgba(0,0,0,.8),rgba(0,0,0,.3), rgba(0,0,0,0)'
	})
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style >
#fuckPadding > .v-parallax__content {
  padding: 0px !important;
}
</style>
