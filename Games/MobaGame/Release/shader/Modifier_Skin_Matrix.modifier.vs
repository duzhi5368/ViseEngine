float4x3 AbsBoneMatrices[68];

void NewSkinVS(inout VertexTrans sem)
{
	float3      Pos = 0.0f;
	float3      Normal = 0.0f;    

	for( int i = 0; i < 4; i++ )
	{
		Pos += mul( float4(sem.mLocalPos,1), AbsBoneMatrices[sem.mBones[i]] ) * sem.mWeights[i];
		// Normal ֻ����תӰ��
		Normal += mul( sem.mLocalNorm, AbsBoneMatrices[sem.mBones[i]] ) * sem.mWeights[i];	
	}
	
	sem.mLocalPos = Pos;
	sem.mLocalNorm = Normal;	

//      PNT MODIFIER�ṩ��WORLD-PROJ-VIEW���㣬 ����ģ�͵�ʱ���Զ�����PNT MODIFIER
//	sem.mProjPos = mul( float4( sem.mLocalPos.xyz, 1), g_WorldViewProjection );

//	sem.mViewVertexNormal = mul( float4(sem.mLocalNorm, 0), g_WorldView ).xyz;
//	sem.mViewVertexNormal = normalize(sem.mViewVertexNormal);

}