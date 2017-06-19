namespace HmadeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intergrate_AspnetIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Products", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Products", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Products", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategorys", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategorys", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ProductCategorys", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Pages", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Pages", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Pages", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Posts", "UpdatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Products", "MetaKeyword", c => c.String(maxLength: 256));
            AlterColumn("dbo.Products", "MetaDescription", c => c.String(maxLength: 256));
            AlterColumn("dbo.ProductCategorys", "MetaKeyword", c => c.String(maxLength: 256));
            AlterColumn("dbo.ProductCategorys", "MetaDescription", c => c.String(maxLength: 256));
            AlterColumn("dbo.Pages", "MetaKeyword", c => c.String(maxLength: 256));
            AlterColumn("dbo.Pages", "MetaDescription", c => c.String(maxLength: 256));
            AlterColumn("dbo.PostCategories", "MetaKeyword", c => c.String(maxLength: 256));
            AlterColumn("dbo.PostCategories", "MetaDescription", c => c.String(maxLength: 256));
            AlterColumn("dbo.Posts", "MetaKeyword", c => c.String(maxLength: 256));
            AlterColumn("dbo.Posts", "MetaDescription", c => c.String(maxLength: 256));
            DropColumn("dbo.Products", "CreateBy");
            DropColumn("dbo.Products", "UpdateDate");
            DropColumn("dbo.Products", "UpdateBy");
            DropColumn("dbo.ProductCategorys", "CreateBy");
            DropColumn("dbo.ProductCategorys", "UpdateDate");
            DropColumn("dbo.ProductCategorys", "UpdateBy");
            DropColumn("dbo.Pages", "CreateBy");
            DropColumn("dbo.Pages", "UpdateDate");
            DropColumn("dbo.Pages", "UpdateBy");
            DropColumn("dbo.PostCategories", "CreateBy");
            DropColumn("dbo.PostCategories", "UpdateDate");
            DropColumn("dbo.PostCategories", "UpdateBy");
            DropColumn("dbo.Posts", "CreateBy");
            DropColumn("dbo.Posts", "UpdateDate");
            DropColumn("dbo.Posts", "UpdateBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UpdateBy", c => c.String());
            AddColumn("dbo.Posts", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Posts", "CreateBy", c => c.String());
            AddColumn("dbo.PostCategories", "UpdateBy", c => c.String());
            AddColumn("dbo.PostCategories", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "CreateBy", c => c.String());
            AddColumn("dbo.Pages", "UpdateBy", c => c.String());
            AddColumn("dbo.Pages", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Pages", "CreateBy", c => c.String());
            AddColumn("dbo.ProductCategorys", "UpdateBy", c => c.String());
            AddColumn("dbo.ProductCategorys", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.ProductCategorys", "CreateBy", c => c.String());
            AddColumn("dbo.Products", "UpdateBy", c => c.String());
            AddColumn("dbo.Products", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Products", "CreateBy", c => c.String());
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            AlterColumn("dbo.Posts", "MetaDescription", c => c.String());
            AlterColumn("dbo.Posts", "MetaKeyword", c => c.String());
            AlterColumn("dbo.PostCategories", "MetaDescription", c => c.String());
            AlterColumn("dbo.PostCategories", "MetaKeyword", c => c.String());
            AlterColumn("dbo.Pages", "MetaDescription", c => c.String());
            AlterColumn("dbo.Pages", "MetaKeyword", c => c.String());
            AlterColumn("dbo.ProductCategorys", "MetaDescription", c => c.String());
            AlterColumn("dbo.ProductCategorys", "MetaKeyword", c => c.String());
            AlterColumn("dbo.Products", "MetaDescription", c => c.String());
            AlterColumn("dbo.Products", "MetaKeyword", c => c.String());
            DropColumn("dbo.Posts", "UpdatedBy");
            DropColumn("dbo.Posts", "UpdatedDate");
            DropColumn("dbo.Posts", "CreatedBy");
            DropColumn("dbo.PostCategories", "UpdatedBy");
            DropColumn("dbo.PostCategories", "UpdatedDate");
            DropColumn("dbo.PostCategories", "CreatedBy");
            DropColumn("dbo.Pages", "UpdatedBy");
            DropColumn("dbo.Pages", "UpdatedDate");
            DropColumn("dbo.Pages", "CreatedBy");
            DropColumn("dbo.ProductCategorys", "UpdatedBy");
            DropColumn("dbo.ProductCategorys", "UpdatedDate");
            DropColumn("dbo.ProductCategorys", "CreatedBy");
            DropColumn("dbo.Products", "UpdatedBy");
            DropColumn("dbo.Products", "UpdatedDate");
            DropColumn("dbo.Products", "CreatedBy");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
        }
    }
}
