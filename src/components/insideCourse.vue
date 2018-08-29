<template>
	<v-container fluid  class='ma-0 pa-0'>
		<v-layout>
			<v-flex xs12>
				<v-card v-bind:style='{"background-color": courseData.backgroundColor}'>
					<v-layout wrap row>
						<v-flex xs2 class='mt-2'>
							<v-card-media src='https://developer.salesforce.com/resource/images/trailhead/trails/trailhead_trail_learn_privacy_and_data_protection_law.png' height='160px' contain/>
						</v-flex>
						<v-flex xs10>
							<v-card-text class='title font-weight-regular pt-4 pb-1 white--text'>Trail</v-card-text>
							<v-card-title class='display-1 font-weight-medium pt-0 pb-2 white--text'>Learn Privacy and Data Protection Law</v-card-title>
							<v-card-text class='body-2 font-weight-medium pt-0 pb-3 white--text'>Learn about laws and regulations for collecting personal data, using it, and protecting privacy.</v-card-text>
							<v-layout row wrap>
								<v-flex xs2>
									<v-card-text class='body-2 font-weight-medium pt-0 pb-4 white--text'>1 hr 35 mins</v-card-text>
								</v-flex>
								<v-spacer/>
								<v-flex xs6 class='mr-5' align-end justify-center>
									<v-layout align-top justify-end row class=''>
										<v-btn class='roleBtn mr-1 ml-0 mt-0'  v-for='i in courseData.roles' small depressed color='grey lighten-2'>{{i.name}}</v-btn>
										<!--
										<v-btn class='roleBtn' small depressed color='grey lighten-2'>test</v-btn>
										<v-btn class='roleBtn' small depressed color='grey lighten-2'>test</v-btn>
									-->
										<v-btn class='lvlBtn mr-1 ml-0 mt-0' small depressed color='grey lighten-2'>{{courseData.tags[0].name}}</v-btn>
										<v-icon id='favIcon' class='mb-2 ml-2'>favorite_border</v-icon>
									</v-layout>
								</v-flex>
							</v-layout>
						</v-flex>
					</v-layout>
				</v-card>
			</v-flex>
		</v-layout>




		<v-layout>
			<v-flex xs9 style='border-right: darkgrey 1px solid'>

				<v-layout wrap column>
					<v-flex v-for='i in modulesData' xs12>
						<v-card class='mx-4 mt-4 mb-0' hover height='260px'>
							<v-layout row class='pb-4'>
								<v-flex xs1 class='mt-4 ml-4 mr-2'>
									<v-card-media
										v-bind:src='i.imageLink'
										height='86px'
										contain
										v-on:click="greet"
									/>
								</v-flex>
								<v-flex xs9 class='mt-3'>
									<v-card-title primary-title>
										<v-layout align-start justify-end column>
											<div class='blue--text title'>{{i.name}}</div>
											<div class='black--text pt-2'>{{i.description}} Modules</div>
										</v-layout>
									</v-card-title>
								</v-flex>
							</v-layout>
							<v-layout>
								<v-flex xs12>
									<v-list class='grey'>
										<v-list-group
											v-for="item in lessons"
											:key="item.title"
											no-action
										>
											<v-list-tile slot="activator">
												<v-list-tile-content>
													<v-list-tile-title>{{item.title }}</v-list-tile-title>
												</v-list-tile-content>
											</v-list-tile>
					
											<v-list-tile
												v-for="subItem in item.items"
												:key="subItem.title"
												@click=""
											>
												<v-list-tile-content>
													<v-list-tile-title>{{ subItem.title }}</v-list-tile-title>
												</v-list-tile-content>
					
												<v-list-tile-action>
													<v-icon>{{ subItem.action }}</v-icon>
												</v-list-tile-action>
											</v-list-tile>
										</v-list-group>
									</v-list>
								</v-flex>
							</v-layout>
						</v-card>
					</v-flex>
				</v-layout>
			</v-flex>
			<v-flex xs3 class='py-5 px-4'>
				<h3>About this course</h3>
				<p>Learn about laws and regulations for collecting personal data, using it, and protecting privacy.</p>
			</v-flex>
		</v-layout>
	</v-container>
</template>

<script>

import axios from 'axios'
var transferedCourseData,transferedModulesData;
export default {
	name: 'insideCourse',
	created() {
		transferedCourseData = this.$route.params.data
		transferedCourseData.backgroundColor = '#00796B'
		console.log(transferedCourseData);
		runWebCalculation({ 
			serviceName: '_LMS.COURSES.GETMODULES',
			parameters: {courseId: transferedCourseData.courseId},
			onSuccess: function(data) {
				transferedModulesData = data.modules;
				console.log(transferedModulesData);
			}
		});
	},    
	data: () => ({
		courseData: transferedCourseData,
		modulesData: transferedModulesData,
		lessons: [
			{
				action: 'local_activity',
				title: 'Attractions',
				items: [
					{ title: 'List Item' },
					{ title: 'List Item' },
					{ title: 'List Item' }
				]
			}
		]
	}),
	// определяйте методы в объекте `methods`
  methods: {
    greet: function () {
      console.log(this);
    }
  }
}

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

</script>

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
	transform: scale(.9);
}
.lvlBtn {
	transform: scale(.9);
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
