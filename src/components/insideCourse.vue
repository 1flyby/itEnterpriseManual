<template>
	<v-container fluid  class='ma-0 pa-0'>

		<!--COURSE HEADER-->
		<v-layout class='mb-3'>
			<v-flex xs12  id='modulesHeader'>
				<!--<v-card v-bind:style='{"background-color": courseData.backgroundColor}'>-->
				<v-card style='background-color: rgba(35,85,0,.8)'>
					<v-layout wrap row>
						<v-flex xs2 class='mt-4'>
							<v-card-media v-bind:src='courseData.imageLink' height='130px' contain/>
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
										<v-btn class='lvlBtn mr-1 ml-0 mt-0' small depressed color='grey lighten-2'>{{courseData.tags[0].name}}</v-btn>
										<v-icon id='favIcon' v-bind:color='favIconColor' @mouseenter='favIconColor = "red"' @mouseleave='favIconColor = "white"' @click='courseData.isFavorite = !courseData.isFavorite'>{{courseData.isFavorite === true ? 'favorite' : 'favorite_border'}}</v-icon>
									</v-layout>
								</v-flex>
							</v-layout>
						</v-flex>
					</v-layout>				
				</v-card>
			</v-flex>
		</v-layout>

		<!--MODULES CONT-->
		<v-layout>
			<v-flex xs9 style='border-right: darkgrey 1px solid'>
				<v-layout wrap column>
					<v-flex v-for='i in modulesData' xs12>
						<v-card class='mx-4 mt-2 mb-0' hover>
							<v-layout row class='pb-4'>
								<v-flex xs1 class='mt-4 ml-4 mr-2'>
									<v-card-media v-bind:src='i.imageLink' height='86px' contain/>
								</v-flex>
								<v-flex xs9 class='mt-3'>
									<v-card-title primary-title>
										<v-layout align-start justify-end column>
											<div class='light-blue--text text--darken-4 title'>{{i.name}}</div>
											<div class='black--text pt-2'>{{i.description}}</div>
										</v-layout>
									</v-card-title>
								</v-flex>
							</v-layout>
							<v-layout reverse column>
								<v-flex xs12>
									<v-list two-line class='py-0'>
										<v-list-group>
											<v-list-tile slot="activator" v-bind:style='{"height":"48px"}'>
												<v-list-tile-content class='pb-4'>
													<v-list-tile-title class='light-blue--text text--darken-3'>Show {{i.units.length}} lesson{{i.units.length === 1 ? '' : 's'}}</v-list-tile-title>
												</v-list-tile-content>
											</v-list-tile>
											<v-list-tile v-for='subItem in i.units' :key='subItem.name' @click=''>
												<v-list-tile-content class='px-2'>
													<v-list-tile-title @click='$router.push({name: "lesson", params: {
														lessonData: subItem,
														lessonName: subItem.name,
														courseId: courseData.courseId,
														courseName: courseData.name,
														moduleId: i.moduleId,
														moduleName: i.name
													}})' class='light-blue--text text--darken-4 font-weight-medium'>{{subItem.name}}</v-list-tile-title>
													<v-list-tile-sub-title>{{subItem.durationMinutes}} mins</v-list-tile-sub-title>
												</v-list-tile-content>
											</v-list-tile>
											<v-divider/>
										</v-list-group>
									</v-list>
								</v-flex>
							</v-layout>
						</v-card>
					</v-flex>
				</v-layout>
			</v-flex>
			
			<!--RIGHT PANEL-->
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
	beforeCreate() {
		transferedCourseData = this.$route.params.courseData
		console.log(transferedCourseData);
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
		runWebCalculation({ 
			serviceName: '_LMS.COURSES.GETMODULES',
			parameters: {courseId: transferedCourseData.courseId},
			onSuccess: function(data) {
				transferedModulesData = data.modules;
				console.log(transferedModulesData);
			}
		});
	},
	mounted () {
		var listHeader = document.getElementsByClassName('v-list__group__header')[0];
		var parentNode = listHeader.parentNode;
		var lists = document.getElementsByClassName(parentNode.getAttribute('class'));

		Array.prototype.forEach.call(lists, function(list) {
			listHeader = list.firstChild;
			var listContent = list.lastChild;
			list.insertBefore(listHeader, listContent.nextSibling);
		});
	},
	data: () => ({
		favIconColor: 'white',
		courseData: transferedCourseData,
		modulesData: transferedModulesData
	})
}
</script>

<style scoped>
#favIcon {
	margin: 0px 0px 6px 8px;
	-webkit-touch-callout: none;
	-webkit-user-select: none;
	-khtml-user-select: none;
	-moz-user-select: none;
	-ms-user-select: none;
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
.cardTitle {
	cursor: pointer;
}
</style>
