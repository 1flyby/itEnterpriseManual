<template>
	<v-container fluid>
		<v-layout wrap row>
			<v-flex v-for='i in courseCards' xs4>
				<v-card style='margin: 20px 20px 0px 0px' hover height='260px'>
					<v-layout v-bind:style="{'background-color': i.backgroundColor}">
						<v-flex xs5>
							<v-card-media
								v-bind:src='i.imageLink'
								height='90px'
								contain
							/>
						</v-flex>
						<v-flex xs7>
							<v-card-title primary-title>
								<v-layout align-end justify-end column>
									<div class='white--text' style='font-size:14px;font-weight:600'>{{i.durationMinutes}}</div>
									<div class='white--text' style='font-size:14px;font-weight:600'>{{i.modulesQt}} Modules</div>
								</v-layout>
							</v-card-title>
						</v-flex>
					</v-layout>
					<div style='height:118px;overflow:hidden' class='mt-2 ml-3'>
						<h4 class='caption font-weight-medium' style='color:rgba(0,0,0,.5)'>{{i.type}}</h4>
						<h3 class='cardTitle subheading font-weight-medium mb-1 blue--text'
							@click='$router.push({name: "insideCourse", params: {courseId: i.courseId, courseData: i}})'
						>{{i.name}}</h3>
						<div class='.body-2'>{{i.description}}</div>
					</div>
					<v-divider light></v-divider>
					<v-layout align-end justify-center row>
						<v-icon id='favIcon' v-bind:color='i.favIconColor' @mouseenter='i.favIconColor = "red"' @mouseleave='i.favIconColor = "grey"' @click='i.favIconStyle=(i.favIconStyle=="favorite"?"favorite_border":"favorite")'>{{i.favIconStyle}}</v-icon>
						<v-spacer/>
						<v-btn class='roleBtn' small depressed color='grey lighten-2'>{{i.roles[0].name}}</v-btn>
						<v-btn class='lvlBtn' small depressed color='grey lighten-2'>{{i.levels[0].name}}</v-btn>
					</v-layout>
				</v-card>
			</v-flex>
		</v-layout>
	</v-container>
</template>

<script>
var courseCardsData;

import axios from 'axios'

/*
var courseCardsData = [
	{ 
		backgroundColor: 'cyan darken-3',
		imageLink: 'https://developer.salesforce.com/resource/images/trailhead/trails/trailhead_trail_learn_privacy_and_data_protection_law.png',
		duration: '1 hr 35 mins',
		modulesQt: '2 Modules',
		name: 'Learn Privacy and Data Protection Law',
		description: 'Learn about laws and regulations for collecting personal data, using it, and protecting privacy.',
		favIconStyle: 'favorite_border',
		favIconColor: 'grey',
		roles: 'Business User',
		levels: 'Beginner'
	},
	{ 
		backgroundColor: 'amber accent-4',
		imageLink: 'https://developer.salesforce.com/resource/images/trailhead/trails/trailhead_trail_use_marketing_cloud_connect_to_integrate_with_salesforce_crm.png',
		duration: '1 hr 40 mins',
		modulesQt: '2 Modules',
		name: 'Use Marketing Cloud Connect to Integrate with Salesforce CRM',
		description: 'Learn how the powerful features of Marketing Cloud Connect can integrate your sales, ',
		favIconStyle: 'favorite_border',
		favIconColor: 'grey',
		roles: 'Admin',
		levels: 'Intermediate'
	},
	{ 
		backgroundColor: 'teal darken-1',
		imageLink: 'https://developer.salesforce.com/resource/images/trailhead/trails/trailhead_trail_accelerate_analytics_with_wave_apps.png',
		duration: '5 hr 55 mins',
		modulesQt: '4 Modules',
		name: 'Accelerate Analytics with Apps',
		description: 'Learn how out-of-the-box apps can help you go faster with Analytics.',
		favIconStyle: 'favorite_border',
		favIconColor: 'grey',
		roles: 'Admin',
		levels: 'Intermediate'
	},
	{ 
		backgroundColor: 'brown lighten-1',
		imageLink: 'https://developer.salesforce.com/resource/images/trailhead/trails/trailhead_trail_achieve_your_goals_with_salesforce_success_cloud.png',
		duration: '2 hr 10 mins',
		modulesQt: '4 Modules',
		name: 'Achieve Your Goals with Salesforce Success Cloud',
		description: 'Discover Salesforce Success Cloud resources and make the most of your Salesforce ',
		favIconStyle: 'favorite_border',
		favIconColor: 'grey',
		roles: 'Admin',
		levels: 'Beginner'
	},
	{ 
		backgroundColor: 'blue-grey darken-1',
		imageLink: 'https://developer.salesforce.com/resource/images/trailhead/trails/trailhead_trail_admin_advanced.png',
		duration: '7 hr 40 mins',
		modulesQt: '6 Modules + 3 Projects',
		name: 'Admin Advanced',
		description: 'Reach all star admin status by tackling more advanced Salesforce features.',
		favIconStyle: 'favorite_border',
		favIconColor: 'grey',
		roles: 'Admin',
		levels: 'Advanced'
	}
]
*/

function runWebCalculation (params) {
axios({
	method: 'post',
	url: 'https://m.it.ua/ws/webservice.asmx/ExecuteEx?pureJSON=',
	data: {
		calcId: params.serviceName,
		args: JSON.stringify(params.parameters),
		ticket: ''
	}
})
.then(function (response) {
	console.log
	// handle success
	params.onSuccess(response.data);
})
.catch(function (error) {
	// handle error
	console.log(error);
	if(params.onError)
	{
		params.onError(error);
	}
})
.then(function () {
	// always executed
	if(params.finnaly)
	{
		params.finnaly();
	}
});
}
export default {
	name: 'Courses',
	created() {
		runWebCalculation({
			serviceName: '_LMS.COURSES.GET',
			parameters: { },
			onSuccess: function(data) {
				courseCardsData = data.courses; 
				console.log(courseCardsData[0].durationMinutes);
			}
		});
	},
	data: () => ({
		courseCards: courseCardsData
	})
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#favIcon {
	margin: 0px 0px 6px 8px;
	-webkit-touch-callout: none; /* iOS Safari */
	-webkit-user-select: none; /* Safari */
	-khtml-user-select: none; /* Konqueror HTML */
	-moz-user-select: none; /* Firefox */
	-ms-user-select: none; /* Internet Explorer/Edge */
	user-select: none;
}
.roleBtn {
	transform: translate(23px,0px) scale(.8);
}
.lvlBtn {
	transform: scale(.8);
}
.roleBtn,.lvlBtn {
	font-size: 13px;
	color: rgb(120,120,120) !important;
}
.v-card--hover {
	cursor: default !important;
}
.cardTitle,.v-card__media {
	cursor: pointer;
}
</style>
